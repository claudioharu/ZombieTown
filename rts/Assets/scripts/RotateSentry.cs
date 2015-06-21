using UnityEngine;
using System.Collections;

public class RotateSentry : MonoBehaviour {

	public float sensitivityX = 15;
	public float sensitivityY= 15;
	
	//Camera that acts as a point of view to rotate the object relative to.
	public Transform referenceCamera;

	private bool isSelected = false;

	// Use this for initialization
	void Start () {
		if (!referenceCamera) {
			if (!Camera.main) {
				Debug.LogError("No Camera with 'Main Camera' as its tag was found. Please either assign a Camera to this script, or change a Camera's tag to 'Main Camera'.");
				Destroy(this);
				return;
			}
			referenceCamera = Camera.main.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		print(isSelected);
		if (isSelected){
			print ("eu");
			//Get how far the mouse has moved by using the Input.GetAxis().
			float rotationX = Input.GetAxis("Mouse X") * sensitivityX;
			
			transform.RotateAroundLocal( referenceCamera.forward , -Mathf.Deg2Rad * rotationX );
			isSelected = true;
		}

	}

	void OnMouseDown(){
		isSelected = true;
	}

	void OnMouseUp(){
		isSelected = false;
	}
}
