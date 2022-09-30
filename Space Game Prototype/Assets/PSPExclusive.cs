using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSPExclusive : MonoBehaviour
{
    public GameObject Simulator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Venus") {
            Simulator.GetComponent<Simulation>().FlybyHappening = true;
        }
        if(other.gameObject.tag == "EndTrigger") {
            Simulator.GetComponent<Simulation>().EndTriggered = true;
        }
        if(other.name == "CoronaTrigger") {
            Simulator.GetComponent<Simulation>().ActivateCorona();
        }
    }
}
