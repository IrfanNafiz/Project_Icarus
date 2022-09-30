using UnityEngine;

public class FirstPersonCameraRotation : MonoBehaviour {

    public Transform target;

	public float Sensitivity {
		get { return sensitivity; }
		set { sensitivity = value; }
	}
	[Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
	[Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

	Vector2 rotation = Vector2.zero;
	const string xAxis = "Mouse X";
	const string yAxis = "Mouse Y";

	Ray ray;
	RaycastHit hit;

    void Start() {
        transform.LookAt(target);
    }

	void CustomMouseInput(){
		RaycastHit hit;

		if (Physics.Raycast(transform.position, transform.forward, out hit)) {
			Debug.Log(hit.transform.name);
		}
	}

	void Update(){
		// CustomMouseInput();
		rotation.x += Input.GetAxis(xAxis) * sensitivity;
		rotation.y += Input.GetAxis(yAxis) * sensitivity;
		rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
		var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
		var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

		transform.localRotation = xQuat * yQuat;
    }
}