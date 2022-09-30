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

    public GameObject mainMenuUI;
    public GameObject UI;

    public TMP_Text InfoText;


    public bool init_anim_complete = false;

    public GameObject[] POI;
    public Button[] Buttons;

    // Start is called before the first frame update
    void Start()
    {
        HideButtons();

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

        init_anim.Play();

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

    // Update is called once per frame
    void Update()
    {
        if (init_anim_complete)
        {
            camera_switcher.switchCamera(round_cam);
            mainMenuUI.SetActive(true);
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
        UI.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Countdown");
        Invoke("Launch", 10.0f);
    }

    public void Launch()
    {
        FindObjectOfType<AudioManager>().Play("Launch");
        foreach (ParticleSystem p in rocket_flames) p.Play();
        foreach (ParticleSystem p in floor_smokes) p.Play();
        takeoff_script.launch();
    }

}
