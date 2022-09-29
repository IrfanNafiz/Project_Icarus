using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraSwitcher
{
    static List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    public static CinemachineVirtualCamera active = null;

    public static bool IsActiveCamera(CinemachineVirtualCamera cam) {
        return cam == active;
    }

    // public static CinemachineFreeLookCamera freecam = null;

    public static void SwitchCam(CinemachineVirtualCamera cam) {
        cam.Priority = 10;
        active = cam;

        foreach(CinemachineVirtualCamera c in cameras) {
            if(c != cam) {
                c.Priority = 0;
            }
        }

        if(cam.GetComponent<CameraProps>().ShowTrailRenderer == false) {
            cam.GetComponent<CameraProps>().Probe.GetComponent<TrailRenderer>().emitting = false;
            cam.GetComponent<CameraProps>().Probe.GetComponent<TrailRenderer>().enabled = false;
        } else {
            cam.GetComponent<CameraProps>().Probe.GetComponent<TrailRenderer>().enabled = true;
            cam.GetComponent<CameraProps>().Probe.GetComponent<TrailRenderer>().emitting = true;
        }
    }

    public static void Register(CinemachineVirtualCamera cam) {
        cameras.Add(cam);
        Debug.Log("Camera Registered: " + cam);
    }

    public static void Unregister(CinemachineVirtualCamera cam) {
        cameras.Remove(cam);
        Debug.Log("Camera Unegistered: " + cam);
    }
}
