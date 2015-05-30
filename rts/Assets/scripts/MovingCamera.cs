using UnityEngine;
using System.Collections;

public class MovingCamera : MonoBehaviour {

	public float camSpeed = 1.0f;
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



	}
}
