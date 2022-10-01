using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSPExclusive : MonoBehaviour
{
    public Simulation simp;
    public Transform target;
    public float speed = 10.69f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var delta = (target.position - transform.position);
        delta.Normalize();
        delta = delta * speed * simp.physicsTimeStep;

        rb.MovePosition(transform.position + delta);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Venus") {
            simp.FlybyHappening = true;
        }
        if(other.gameObject.tag == "EndTrigger") {
            simp.EndTriggered = true;
        }
        if(other.name == "CoronaTrigger") {
            simp.ActivateCorona();
        }
    }
}