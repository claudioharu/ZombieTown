using UnityEngine;
using System.Collections;

public class tst : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GUI.Label(new Rect(0,-1000 + (Time.time*100),Screen.width, 1000),"Some long text");
	}
}
