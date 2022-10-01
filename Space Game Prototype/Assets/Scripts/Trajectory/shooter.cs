using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{

    public GameObject ball, simulation_container;
    public SimulationTrajectory simulation;
    private List<GameObject> instances = new List<GameObject>();
    private int ballCount = 0;
    public float velocity = 0f, angle = 90f;
    public Vector3 velocity_vector = new Vector3(0, 0, 1);


    private void Awake()
    {
        Time.timeScale = 10;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        simulation = simulation_container.GetComponent<SimulationTrajectory>();
        Debug.Log(simulation_container);
        Debug.Log(simulation);
    }



    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.A ) ) {

            foreach (GameObject g in instances) {
                simulation.RemoveBody(g.GetComponent<StellarBody>());
                Destroy(g.GetComponent<StellarBody>());
                Destroy(g);
            }
            instances.Clear();
;
            Vector3 randomPosition = Vector3.zero + Random.insideUnitSphere * 10;
            instances.Add( (GameObject)Instantiate( ball, transform.position, Quaternion.identity ) );

            foreach( GameObject g in instances )
            {
                StellarBody s = g.GetComponent<StellarBody>();
                s.initialVelocity = velocity_vector;
                s.surfaceGravity = 1.67f;
                s.bodyName = "trajectory" + ballCount;
                ballCount++;
                simulation.AddBody(s);
                s.initialize();

                //Debug.Log("sim data: " + s.bodyName + " sim2: " + s.rb + " sim3: " + simulation.bodies.Count);
            }
        }

        if( Input.GetKey(KeyCode.UpArrow) )
        {
            velocity += 1f;
        } else if( Input.GetKey(KeyCode.DownArrow) )
        {
            velocity -= 1f;
        } 
        
        if( Input.GetKey( KeyCode.LeftArrow ) )
        {
            angle += 1f;
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            angle -= 1f;
        }

        velocity_vector.x = Mathf.Cos(Mathf.Deg2Rad * angle);
        velocity_vector.z = Mathf.Sin(Mathf.Deg2Rad * angle);

        velocity_vector *= velocity;

        //VectorLine.SetLine(Color.white, Vector2(100, 50), Vector2(250, 120));
    }
}
