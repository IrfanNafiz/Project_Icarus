using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class circle_around : MonoBehaviour
{

    public CinemachineVirtualCamera cam;
    public CinemachineTrackedDolly dolly;
    public float camPos = 0;
    // Start is called before the first frame update

    private void Start()
    {
        dolly = cam.GetCinemachineComponent<CinemachineTrackedDolly>();
        Debug.Log(dolly);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) {
            camPos = camPos + Time.deltaTime;
        } else if(Input.GetKey(KeyCode.A)) {
            camPos = camPos - Time.deltaTime;
        }

        dolly.m_PathPosition = camPos;
    }
}
