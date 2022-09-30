using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Simulation : MonoBehaviour
{
    public static float physicsTimeStep = 0.01f;
    public string name = "default";
    public bool FlybyHappening = false;
    
    public bool EndTriggered = false;

    public Camera TargetCamera;

    public Button[] Buttons;

    public GameObject[] POI;

    public GameObject VideoPanel;
    
    public GameObject FlybyVideo;

    public GameObject CoronalVideo;

    public TMP_Text VideoTitle;

    public TMP_Text InstructionText;

    private bool Prompted = false;

    private Transform CameraState;

    public List<StellarBody> bodies = new List<StellarBody>();
    public static Simulation instance;
    public GameObject gm;

    void Start() {
        for(int i = 0; i< Buttons.Length; i++){
            Buttons[i].GetComponent<Image>().enabled = false;
        }
    }

    void Awake()
    {
        Debug.Log(gameObject.name);
        TargetCamera.GetComponent<CameraFollow>().enabled = true;
        TargetCamera.GetComponent<FirstPersonCameraRotation>().enabled = false;


        StellarBody[] bodies_arr = FindObjectsOfType<StellarBody>();
        
        foreach( StellarBody s in bodies_arr )
        {
            bodies.Add( s );
        }


        
        Time.fixedDeltaTime = physicsTimeStep;
        Debug.Log("Setting fixedDeltaTime to: " + physicsTimeStep);
    }

    public void AddBody(StellarBody s)
    {
        // bodies.Append(body);

        Debug.Log("before: " + bodies.Count);
        foreach (StellarBody body in bodies)
        {
            Debug.Log("before: " + body.bodyName);
        }

        bodies.Add(s);

        Debug.Log("after: " + bodies.Count);
        foreach (StellarBody body in bodies)
        {
            Debug.Log("after: " + body.bodyName);
        }

    }

    public void RemoveBody( StellarBody s )
    {
        List<StellarBody> bodies_temp = new List<StellarBody>();

        Debug.Log("before: " + bodies.Count);
        foreach( StellarBody body in bodies )
        {
            Debug.Log("before: " + body.bodyName);
        }

        foreach (StellarBody body in bodies)
        {
            if (body.bodyName != s.bodyName) bodies_temp.Add(body);
        }

        Debug.Log("Removed " + (bodies.Count - bodies_temp.Count) );

        bodies = bodies_temp;

    }
    
    void SetUI(){
        for(int i = 0; i< POI.Length; i++) {
            Vector3 ScreenPos = TargetCamera.WorldToScreenPoint(POI[i].transform.position);
            Vector3 viewPos = TargetCamera.WorldToViewportPoint(POI[i].transform.position);
            if (viewPos.z > 0)
            {
                Buttons[i].transform.position = ScreenPos;
                Buttons[i].GetComponent<Image>().enabled = true;
                
            } else {
                Buttons[i].GetComponent<Image>().enabled = false;
            }
        }
    }

    void DoButtonThings(string name) {
        Debug.Log("Button Pressed: " + name);
    }

    public void ActivateCorona(){
        InstructionText.text = "";
        FlybyVideo.SetActive(false);
        CoronalVideo.SetActive(true);
        VideoTitle.text = "Encountering Solar Coronal Stream";
    }

    void Update(){
        if (EndTriggered)
        {
            Debug.Log("End Scene");
            gm.GetComponent<GameManager>().StartGameTransition();
        }
    }

    void FixedUpdate()
    {
        if (FlybyHappening){
            if(physicsTimeStep > 0) physicsTimeStep -= 0.00005f;
            else {
                physicsTimeStep = 0f;
            }

            if(physicsTimeStep == 0f){
                InstructionText.text = "Click the points to learn more\nPress F to continue";
                VideoPanel.SetActive(true);
                FlybyVideo.SetActive(true);
                VideoTitle.text = "Venus Flyby";
                if(Input.GetKeyDown(KeyCode.F)){
                    // InstructionText.text = "";
                    // FlybyVideo.SetActive(false);
                    // CoronalVideo.SetActive(true);
                    // VideoTitle.text = "Encountering Solar Coronal Stream";
                    TargetCamera.GetComponent<FirstPersonCameraRotation>().enabled = false;
                    TargetCamera.GetComponent<CameraFollow>().enabled = true;
                    Prompted = true;
                }

                if(!Prompted) {
                    SetUI();
                    TargetCamera.GetComponent<CameraFollow>().enabled = false;
                    TargetCamera.GetComponent<FirstPersonCameraRotation>().enabled = true;
                }
            }
        }


        if(Prompted){
            for(int i = 0; i< Buttons.Length; i++) {
                Buttons[i].GetComponent<Image>().enabled = false;
                Buttons[i].GetComponent<ButtonScript>().Deactivate();
            }
            if(physicsTimeStep < 0.01f) physicsTimeStep += 0.00008f;
            else physicsTimeStep = 0.01f;
        }
        // Debug.Log("Sim name: " + name + " body count: " + bodies.Count);
        foreach (StellarBody body in bodies)
        {
            // Debug.Log("bodies: " + body.bodyName);
        }
        
        for (int i = 0; i < bodies.Count; i++)
        {
            Vector3 acceleration = CalculateAcceleration(bodies[i].Position, bodies[i]);
            bodies[i].UpdateVelocity(acceleration, physicsTimeStep);
            //bodies[i].UpdateVelocity (bodies, Universe.physicsTimeStep);
        }

        for (int i = 0; i < bodies.Count; i++)
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

    public static List<StellarBody> Bodies
    {
        get
        {
            return Instance.bodies;
        }
    }

    public static Simulation Instance
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