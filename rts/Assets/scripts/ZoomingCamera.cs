using UnityEngine;
using System.Collections;

public class ZoomingCamera : MonoBehaviour {


	//zoom camera
	public float distance = 60.0f;
	public float sensitivityDistance = 50.0f;
	public float damping  = 5.0f;
	public float minFOV = 20.0f;
	public float maxFOV = 100.0f;
	

	// Use this for initialization
	void Start () {
		distance = GetComponent<Camera>().fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance;
		distance = Mathf.Clamp(distance, minFOV, maxFOV);
		GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, distance, Time.deltaTime * damping);
	}
}
