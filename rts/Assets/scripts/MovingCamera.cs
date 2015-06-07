using UnityEngine;
using System.Collections;

public class MovingCamera : MonoBehaviour {

	/*
	 * public float camSpeed = 1.0f;
	public float GUIsize = 40.0f;

	
	// Update is called once per frame
	void Update () {
		Rect recDown = new Rect (0,0, Screen.width, GUIsize);
		Rect recUp = new Rect (0, Screen.height-GUIsize, Screen.width, GUIsize);
		Rect recLeft = new Rect (0,0, GUIsize, Screen.height);
		Rect recRight = new Rect (Screen.width-GUIsize, 0, GUIsize, Screen.height);

		if(recDown.Contains (Input.mousePosition))
			transform.Translate(0,0, -camSpeed, Space.World);

		if(recUp.Contains (Input.mousePosition))
			transform.Translate(0,0, camSpeed, Space.World);

		if(recLeft.Contains (Input.mousePosition))
			transform.Translate(-camSpeed, 0,0, Space.World);

		if(recRight.Contains (Input.mousePosition))
			transform.Translate(camSpeed,0, 0, Space.World);



	}*/
	public float horizontalSpeed = 40;
	public float verticalSpeed = 40;
	public float cameraRotateSpeed = 80;
	private Vector3 CamRotY;

	void Update(){

		float horizontal = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;  
		float vertical = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
		//float rotation = Input.GetAxis("Rotation");

		transform.Translate(Vector3.down * -vertical);
		transform.Translate(Vector3.right * horizontal);

	
		if (Input.GetKey ("q")){
			transform.Rotate (Vector3.up, cameraRotateSpeed * Time.deltaTime, Space.World);
		}
		if(Input.GetKey ("e")){
			transform.Rotate (Vector3.up, -cameraRotateSpeed * Time.deltaTime, Space.World);
		}
	}
}
