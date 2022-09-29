using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class Manager : MonoBehaviour
{
    [SerializeField] GameObject[] planets;

    [SerializeField] GameObject ParkerSolarProbe;

    CinemachineVirtualCamera activeCam = null;

    public bool IsPaused = false;
    private int ConstantTimeScale = 100;

    public TMP_Text camText;
    public TMP_Text ProbeText;
    public TMP_Text BreakText;

    public GameObject CameraPerson;
    private CameraPerson CameraPersonScript;

    public Vector3 probeTextOffset;

    private bool IsBreaking = false;

    Ray ray;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        CameraPersonScript = CameraPerson.GetComponent<CameraPerson>();
    }

    void SetUI(CinemachineVirtualCamera active){
        camText.text = active.GetComponent<CameraProps>().CameraName;
        
        if (active.GetComponent<CameraProps>().AllowProbeText && MouseOverProbe()){
            Vector3 probePos = Camera.main.WorldToScreenPoint(ParkerSolarProbe.transform.position);
            ProbeText.transform.position = probePos + probeTextOffset;
            double velocity = ParkerSolarProbe.GetComponent<SimpleKeplerOrbits.KeplerOrbitMover>().OrbitData.Velocity.x;
            ProbeText.text = "Velocity: " + Mathf.Abs(Mathf.Round((float)velocity * 10000f) * (1/10000f)).ToString();
        } else {
            ProbeText.text = "";
        }

        if (IsBreaking) {
            BreakText.text = "Press B to destruct Probe";
        }

    }

    bool MouseOverProbe(){
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            return hit.collider.name == "Probe";
        }
        return false;
    }

    public void SwitchToFinalShot() {
        CameraPersonScript.ActiveCamIndex = 1;
        CameraSwitcher.SwitchCam(CameraPersonScript.cameras[1]);
        IsBreaking = true;
    }

    // Update is called once per frame
    void Update()
    {
        //IsBreaking = ParkerSolarProbe.GetComponent<SimpleKeplerOrbits.KeplerOrbitMover>().IsBreaking;
        activeCam = CameraPersonScript.cameras[CameraPersonScript.ActiveCamIndex];
        SetUI(activeCam);
        foreach(GameObject planet in planets) {
            if(IsBreaking) {
                continue;
            } else {
                if(IsPaused) {
                    planet.GetComponent<SimpleKeplerOrbits.KeplerOrbitMover>().TimeScale = 0f;
                } else {
                    planet.GetComponent<SimpleKeplerOrbits.KeplerOrbitMover>().TimeScale = ConstantTimeScale;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Tab)){
            IsPaused = !IsPaused;
        }
    }
}
