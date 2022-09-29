using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeoff : MonoBehaviour
{
    
    [Range(0.0f, 100.0f)]
    public float force = 0f;               // By trial and error 100f was found to be optimal for mass==1

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Rigidbody rigidBody;

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.AddForce(0, force, 0);
    }

    public void launch() {
        force = 10f;
    }
}
