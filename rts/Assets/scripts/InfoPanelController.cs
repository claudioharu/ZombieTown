using UnityEngine;
using System.Collections;

public class InfoPanelController : MonoBehaviour {
	public float timeToHideInfo = 5.0f;

	// Use this for initialization
	void Start () {
		Invoke ("hideInfo", timeToHideInfo);
	}

	void hideInfo(){
		Destroy(GameObject.Find("InfoPanel"));
	}	
}
