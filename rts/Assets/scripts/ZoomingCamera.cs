using UnityEngine;
using System.Collections;

public class ZoomingCamera : MonoBehaviour {


	//zoom camera
	public float distance = 10.0f;
	public float sensitivityDistance = 45.0f;
	public float damping  = 5.0f;

	

	// Use this for initialization
	void Start () {
		distance = GetComponent<Camera>().orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (distance <= 45.0f && distance >= 10.0f){
			distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance;
			if(distance >= 45.0f) distance = 45.0f;
			if(distance <= 10.0f) distance = 10.0f;
			print(distance);

			GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, distance, Time.deltaTime * damping);

		}
	}
}
