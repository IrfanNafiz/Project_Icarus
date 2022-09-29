using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProps : MonoBehaviour
{
    [SerializeField]
    public GameObject Probe;

    [SerializeField]
    public bool ShowTrailRenderer = false;

    [SerializeField]
    public bool AllowProbeText = false;

    [SerializeField]
    public string CameraName = "Demo Camera";

    [SerializeField]
    public int CameraNumber;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Show");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
