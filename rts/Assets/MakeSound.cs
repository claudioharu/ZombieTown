using UnityEngine;
using System.Collections;

public class MakeSound : MonoBehaviour {
	public GameObject Sound;
	// Use this for initialization
	void Start () {
		Instantiate(Sound, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
