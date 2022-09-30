using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using Cinemachine;
using Unity.VisualScripting;

public class prelude_scene : MonoBehaviour
{

    public CinemachineVirtualCamera init_cam_psp, round_cam_psp, init_cam_sun, round_cam_sun;
    private PlayableDirector  init_anim_psp, round_anim_psp, init_anim_sun, round_anim_sun;

    public GameObject mainMenuUI;
    public GameObject UI;

    private string current_focused_object;
    private bool init_anim_psp_complete = false;
    private bool init_anim_sun_complete = false;

    // Start is called before the first frame update
    void Start()
    {
        
        camera_switcher.register(init_cam_psp);
        camera_switcher.register(round_cam_psp);

        camera_switcher.register(init_cam_sun);
        camera_switcher.register(round_cam_sun);

        StartPspSequence();

    }

    void OnInitAnimPspStopped(PlayableDirector anim)
    {
        init_anim_psp_complete = true;
    }

    void OnInitAnimSunStopped(PlayableDirector anim)
    {
        init_anim_sun_complete = true;
    }

    void StartPspSequence() {

        current_focused_object = "psp";

        init_anim_psp = init_cam_psp.GetComponent<PlayableDirector>();
        round_anim_psp = round_cam_psp.GetComponent<PlayableDirector>();

        camera_switcher.switchCamera(init_cam_psp);

        init_anim_psp.stopped += OnInitAnimPspStopped;

        init_anim_psp.Play();
    }

    void StartSunSequence() {

        current_focused_object = "sun";

        init_anim_sun = init_cam_sun.GetComponent<PlayableDirector>();
        round_anim_sun = round_cam_sun.GetComponent<PlayableDirector>();

        camera_switcher.switchCamera( init_cam_sun );

        init_anim_sun.stopped += OnInitAnimSunStopped;

        init_anim_sun.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if ( current_focused_object == "psp" && init_anim_psp_complete) {
            camera_switcher.switchCamera(round_cam_psp);
            //mainMenuUI.SetActive(true);
        }

        if( current_focused_object == "sun" && init_anim_sun_complete ) {
            camera_switcher.switchCamera(round_cam_sun);
        }

        if( Input.GetKeyDown(KeyCode.S) ) {
            StartSunSequence();
        }
  
    }

}
