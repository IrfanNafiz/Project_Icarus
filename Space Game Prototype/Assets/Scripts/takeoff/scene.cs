using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using Cinemachine;
using Unity.VisualScripting;
using TMPro;

public class scene : MonoBehaviour
{

    public CinemachineVirtualCamera init_cam, round_cam;
    private PlayableDirector init_anim, round_anim;
    public GameObject rocket, floor;
    private GameObject rocket_flames_container, floor_smoke_container;
    private ParticleSystem[] rocket_flames, floor_smokes;
    private takeoff takeoff_script;
    private bool launched = false;


    public GameObject mainMenuUI;
    public GameObject UI;
    public GameObject POIUI;


    public TMP_Text InfoText;


    public bool init_anim_complete = false;

    public GameObject[] POI;
    public Button[] Buttons;

    CinemachineBasicMultiChannelPerlin perlin;
    private bool shakeRunning = false;
    public float intensity = 3f, falloff = 0.05f;

    private AudioManager SceneAudioManager;
    private string current_playing;

    // Start is called before the first frame update
    void Start()
    {
        HideButtons();

        SceneAudioManager = FindObjectOfType<AudioManager>();

        perlin = round_cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        init_anim = init_cam.GetComponent<PlayableDirector>();
        round_anim = round_cam.GetComponent<PlayableDirector>();
        takeoff_script = rocket.GetComponent<takeoff>();

        rocket_flames_container = rocket.transform.Find("flames").gameObject;
        floor_smoke_container = floor.transform.Find("smoke").gameObject;

        Debug.Log(rocket_flames_container);

        rocket_flames = rocket_flames_container.GetComponentsInChildren<ParticleSystem>();
        floor_smokes = floor_smoke_container.GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem p in rocket_flames) p.Pause();
        foreach (ParticleSystem p in floor_smokes) p.Pause();

        camera_switcher.register(init_cam);
        camera_switcher.register(round_cam);

        camera_switcher.switchCamera(init_cam);
        // init_anim_complete = true;

        init_anim.stopped += OnInitAnimStopped;

        SceneAudioManager.Play("narratorintro");
        current_playing = "narratorintro";

        init_anim.Play();

    }

    void shake() {
        this.shakeRunning = true;
    }

    void OnInitAnimStopped(PlayableDirector anim)
    {
        init_anim_complete = true;
     
    }

    void HideButtons(){
        for(int i = 0; i<Buttons.Length; i++) {
            Buttons[i].GetComponent<Image>().enabled = false;
        }
    }

    void SetUI(){
        for(int i = 0; i< POI.Length; i++) {
            Vector3 ScreenPos = Camera.main.WorldToScreenPoint(POI[i].transform.position);
            Vector3 viewPos = Camera.main.WorldToViewportPoint(POI[i].transform.position);
            if (viewPos.z > 0)
            {
                Buttons[i].transform.position = ScreenPos;
                Buttons[i].GetComponent<Image>().enabled = true;
                
            } else {
                Buttons[i].GetComponent<Image>().enabled = false;
            }
        }
    }

    IEnumerator play_audio(string audio_name, float wait_time)
    {
        yield return new WaitForSeconds(wait_time);
        SceneAudioManager.Play(audio_name);
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("audiomanager state: " + SceneAudioManager.FinishedPlaying("narratorintro"));

        if( SceneAudioManager.FinishedPlaying(current_playing)  ) {
            if( current_playing == "narratorintro" ) {
                SceneAudioManager.Play("1prelaunch2");
                current_playing = "1prelaunch2";
            } else if( current_playing == "1prelaunch2" ) {
                SceneAudioManager.Play("1feelfree");
                current_playing = "1feelfree";
            }
        }

        if( shakeRunning && intensity > 0 ) {
            perlin.m_AmplitudeGain = intensity;
            intensity -= Time.deltaTime * falloff;
        }

        if (init_anim_complete)
        {
            camera_switcher.switchCamera(round_cam);
            if(!launched) mainMenuUI.SetActive(true);
            SetUI();
        } else {
            HideButtons();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            LaunchStart();
        }
    }

    public void LaunchStart()
    {
        launched = true;
        mainMenuUI.SetActive(false);
        POIUI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Countdown");
        StartCoroutine(play_audio("1launch1", 10f));
        StartCoroutine(play_audio("1transition", 42.0f - 5.5f));
        current_playing = "1launch1";
        Invoke("Launch", 10.0f);
        Invoke("shake", 10.0f);
        Invoke("EndScene", 42.0f);
    }

    public void Launch()
    {
        StartCoroutine(play_audio("1launch2", 8f));
        SceneAudioManager.Play("Launch");
        foreach (ParticleSystem p in rocket_flames) p.Play();
        foreach (ParticleSystem p in floor_smokes) p.Play();
        takeoff_script.launch();
    }

    public void EndScene() {
        Debug.Log("End is near!");
        FindObjectOfType<AudioManager>().Stop("Launch");
        FindObjectOfType<GameManager>().GetComponent<GameManager>().StartGameTransition();
    }

}
