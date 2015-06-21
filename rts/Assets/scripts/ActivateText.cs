using UnityEngine;
using System.Collections;

public class ActivateText : MonoBehaviour {

	public GameObject[] objectsToActivate;

	private bool isSelected = false;


	// Update is called once per frame
	void Update () {
		if(isSelected){
			foreach(GameObject obj in objectsToActivate)
			{
				obj.SetActiveRecursively(true);
			}
		}
		else{
			foreach(GameObject obj in objectsToActivate)
			{
				obj.SetActiveRecursively(false);
			}

		}
	}

	void OnMouseDown(){
		isSelected = true;
	}

	void OnMouseUp(){
		isSelected = false;
	}
}
