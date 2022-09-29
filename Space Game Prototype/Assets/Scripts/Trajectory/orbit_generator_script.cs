using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbit_generator_script : MonoBehaviour
{

    public LineRenderer circle_renderer;

    // Start is called before the first frame update
    void Start()
    {
        drawCircle(100, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void drawCircle(int steps, float radius)
    {
        circle_renderer.positionCount = steps;

        for( var current_step = 0; current_step < steps; current_step++ )
        {
            float circumference_progress = (float)current_step / steps;
            float current_radian = (float) current_step / steps;

            float x = Mathf.Cos(current_radian) * radius;
            float y = Mathf.Sin(current_radian) * radius;

            circle_renderer.SetPosition(current_step, new Vector3(x, y, 0));
        }
    }
}
