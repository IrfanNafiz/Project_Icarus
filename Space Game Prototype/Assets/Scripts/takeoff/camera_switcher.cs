using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class camera_switcher
{
    // Start is called before the first frame update
    static List<CinemachineVirtualCamera> cams = new List<CinemachineVirtualCamera>();

    public static void switchCamera(CinemachineVirtualCamera cam) {
        cam.Priority = 10;
        
        foreach ( CinemachineVirtualCamera c in cams )
        {
            if (c != cam) c.Priority = 0;
        }
    }

    public static void register( CinemachineVirtualCamera cam ) {
        cams.Add(cam);
    }
}
