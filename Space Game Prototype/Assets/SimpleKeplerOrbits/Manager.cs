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

    public GameObject CameraPerson;
    private CameraPerson CameraPersonScript;

    public Vector3 probeTextOffset;
    // Start is called before the first frame update
    void Start()
    {
        CameraPersonScript = CameraPerson.GetComponent<CameraPerson>();
    }

    void SetUI(CinemachineVirtualCamera active){
        camText.text = active.GetComponent<CameraProps>().CameraName;
        
        if (active.GetComponent<CameraProps>().AllowProbeText){
            Vector3 probePos = Camera.main.WorldToScreenPoint(ParkerSolarProbe.transform.position);
            ProbeText.transform.position = probePos + probeTextOffset;
            ProbeText.text = ParkerSolarProbe.GetComponent<SimpleKeplerOrbits.KeplerOrbitMover>().OrbitData.Velocity.x.ToString();
        } else {
            ProbeText.text = "";
        }

    }

    public void SwitchToFinalShot() {
        CameraSwitcher.SwitchCam(CameraPersonScript.cameras[1]);
    }

    // Update is called once per frame
    void Update()
    {
        activeCam = CameraPersonScript.cameras[CameraPersonScript.ActiveCamIndex];
        SetUI(activeCam);
        if(Input.GetKeyDown(KeyCode.Tab)){
            foreach(GameObject planet in planets) {
                if(planet.GetComponent<SimpleKeplerOrbits.KeplerOrbitMover>().IsBreaking) {
                    continue;
                } else {
                    IsPaused = !IsPaused;
                    if(IsPaused) {
                        planet.GetComponent<SimpleKeplerOrbits.KeplerOrbitMover>().TimeScale = 0f;
                    } else {
                        planet.GetComponent<SimpleKeplerOrbits.KeplerOrbitMover>().TimeScale = ConstantTimeScale;
                    }
                }
            }
        }
    }
}
