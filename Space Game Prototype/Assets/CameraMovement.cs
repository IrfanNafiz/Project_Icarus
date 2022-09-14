using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 200f;
    public float horizontalForce = 200f;

    // Update is called once per frame
    // We use FixedUpdate because Unity likes it better when used with a physics component.
    void FixedUpdate()
    {
        //***for testing purposes only, enable line "rb.addforce(0, 0, forwardforce * time.deltatime);" in function ***
        //rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.AddForce(horizontalForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.AddForce(-horizontalForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }
        if (Input.GetKey("left shift"))
        {
            rb.AddForce(0, forwardForce * Time.deltaTime, 0);
        }
        if (Input.GetKey("space"))
        {
            rb.AddForce(0, -forwardForce * Time.deltaTime, 0);
        }
    }
}
