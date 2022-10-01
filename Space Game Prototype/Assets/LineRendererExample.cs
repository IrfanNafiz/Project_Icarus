using System.Collections.Generic;
using UnityEngine;

// This example creates a sine wave and then simplifies it using LineRenderer.Simplify.
// The parameters can be adjusted through an in game GUI to allow for experimentation.
[RequireComponent(typeof(LineRenderer))]
public class LineRendererExample : MonoBehaviour
{
    public int numberOfPoints = 1000;
    public float length = 50;
    public float waveHeight = 10;
    public float tolerance = 0.1f;

    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>(); // Generated points before Simplify is used.

    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Generates the sine wave points.
    public void GeneratePoints()
    {
        points.Clear();
        float halfWaveHeight = waveHeight * 0.5f;
        float step = length / numberOfPoints;
        for (int i = 0; i < numberOfPoints; ++i)
        {
            points.Add(new Vector3(i * step, Mathf.Sin(i * step) * halfWaveHeight, 0));
        }
    }

    // Draw a simple GUI slider with a label.
    private static float GUISlider(string label, float value, float min, float max)
    {
        GUILayout.BeginHorizontal(GUILayout.Width(Screen.width / 2.0f));
        GUILayout.Label(label + "(" + value + ") :", GUILayout.Width(150));
        var val = GUILayout.HorizontalSlider(value, min, max);
        GUILayout.EndHorizontal();
        return val;
    }

    public void OnGUI()
    {
        GUILayout.Label("LineRenderer.Simplify", GUI.skin.box);

        // We use GUI.changed to detect if a value was changed via the GUI, if it has we can then re-generate the points and simplify the line again.
        GUI.changed = false;

        numberOfPoints = (int)GUISlider("Number of Points", numberOfPoints, 0, 1000);
        length = GUISlider("Length", length, 0, 100);
        waveHeight = GUISlider("Wave Height", waveHeight, 0, 100);
        if (GUI.changed)
            GeneratePoints();

        tolerance = GUISlider("Simplify Tolerance", tolerance, 0, 2);
        if (GUI.changed)
            lineRenderer.Simplify(tolerance);

        float percentRemoved = 100.0f - ((float)lineRenderer.positionCount / numberOfPoints) * 100.0f;
        if (tolerance > 0.0f)
            GUILayout.Label("Points after simplification: " + lineRenderer.positionCount + "(Removed " + percentRemoved.ToString("##.##") + "%)");
    }
}