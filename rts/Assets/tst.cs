using UnityEngine;
using System.Collections;

public class tst : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.up * Time.deltaTime*100;
	}
}
