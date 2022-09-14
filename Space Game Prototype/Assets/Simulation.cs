using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    public static float physicsTimeStep = 0.01f;

    StellarBody[] bodies;
    static Simulation instance;

    void Awake()
    {

        bodies = FindObjectsOfType<StellarBody>();
        Time.fixedDeltaTime = physicsTimeStep;
        Debug.Log("Setting fixedDeltaTime to: " + physicsTimeStep);
    }

    void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            Vector3 acceleration = CalculateAcceleration(bodies[i].Position, bodies[i]);
            bodies[i].UpdateVelocity(acceleration, physicsTimeStep);
            //bodies[i].UpdateVelocity (bodies, Universe.physicsTimeStep);
        }

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(physicsTimeStep);
        }

    }

    public static Vector3 CalculateAcceleration(Vector3 point, StellarBody ignoreBody = null)
    {
        Vector3 acceleration = Vector3.zero;
        foreach (var body in Instance.bodies)
        {
            if (body != ignoreBody)
            {
                float sqrDst = (body.Position - point).sqrMagnitude;
                Vector3 forceDir = (body.Position - point).normalized;
                acceleration += forceDir * StellarBody.gravConstant * body.mass / sqrDst;
            }
        }

        return acceleration;
    }

    public static StellarBody[] Bodies
    {
        get
        {
            return Instance.bodies;
        }
    }

    static Simulation Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Simulation>();
            }
            return instance;
        }
    }
}