using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPerson : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera[] cameras;
    public int ActiveCamIndex = 0;

    private void OnEnable(){
        foreach(CinemachineVirtualCamera cam in cameras) {
            CameraSwitcher.Register(cam);
        }
    }

    private void OnDisable(){
        foreach(CinemachineVirtualCamera cam in cameras) {
            CameraSwitcher.Unregister(cam);
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            ActiveCamIndex = (ActiveCamIndex + 1) % cameras.Length;
            CinemachineVirtualCamera cam = cameras[ActiveCamIndex];
            CameraSwitcher.SwitchCam(cam);
        }
    }
}
