using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class LineRendering : MonoBehaviour
{
    public GameObject shooterscript;
    public GameObject vectorpoint;
    // Start is called before the first frame update
    void Start()
    {
        vectorpoint = shooterscript.GetComponent<velocity_vector>();
    }

    // Update is called once per frame
    void Update()
    {
    //    LineRenderer lineRenderer = GetComponent<LineRenderer>();
    //    var points = new Vector3[2];
    //    points[0] = transform.position;
    //    points[1] = shooter.velocity_vector;
    //    lineRenderer.SetPositions(points);
    //}
}
