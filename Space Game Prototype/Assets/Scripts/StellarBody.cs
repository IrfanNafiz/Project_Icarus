using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class StellarBody : MonoBehaviour
{
    public static float gravConstant = 6.67384e-11f;

    private Rigidbody rb;
    public float radius;
    public Vector3 initialVelocity;
    public string bodyName = "Unnamed";
    public float surfaceGravity;
    Transform meshHolder;
    public float mass { get; private set; }
    public Vector3 currentVelocity; // { get; public set; }


    private void Awake()
    {
        initialize();
    }

    public void initialize()
    {
        rb = GetComponent<Rigidbody>();
        currentVelocity = initialVelocity;
        rb.mass = mass;
    }

    public void UpdateVelocity(StellarBody[] allBodies, float timeStep)
    {

        Debug.Log("update called for " + bodyName);
        foreach (var otherBody in allBodies)
        {
            if (otherBody != this)
            {
                float sqrDist = (otherBody.rb.position - rb.position).sqrMagnitude;
                Vector3 forceDir = (otherBody.rb.position - rb.position).normalized;
                Vector3 gravitationalAcceleration = forceDir * gravConstant * otherBody.mass / sqrDist;
                currentVelocity += gravitationalAcceleration * timeStep;
            };
        };
    }

    public void UpdateVelocity(Vector3 gravitationalAcceleration, float timeStep) // is this even necessary? Dont know, not removing this cause dont wanna break my damn code.
    {
        currentVelocity += gravitationalAcceleration * timeStep;
    }

    public void UpdatePosition(float timeStep)
    {
        rb.MovePosition(rb.position + currentVelocity * timeStep);
    }

    void OnValidate() //Understand what this means and decide on what to do, 
                        //it caused the clouds to transform scale according to radius set when played (OnValidate effect)
    {
        mass = surfaceGravity * radius * radius / gravConstant;
        //meshHolder = transform.GetChild(1);
        //meshHolder.localScale = Vector3.one * radius;
        //meshHolder = transform.GetChild(0);
        //meshHolder.localScale = Vector3.one * radius;
        gameObject.name = bodyName;
    }

    public Rigidbody Rigidbody
    {
        get
        {
            return rb;
        }
    }

    public Vector3 Position
    {
        get
        {
            return rb.position;
        }
    }
}
