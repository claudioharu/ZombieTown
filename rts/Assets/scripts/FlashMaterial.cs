using UnityEngine;
using System.Collections;

public class FlashMaterial : MonoBehaviour {

	public float flashRate = 1.0f;
	private Color origColor; 	//Texture ?

	// Use this for initialization
	void Start () {
		origColor = GetComponent<Renderer>().material.color; //Get Texture?
		StartCoroutine("Flash");
	}
	

	IEnumerator Flash () {
		float t = 0;
		while(t < flashRate){
			GetComponent<Renderer>().material.color = Color.Lerp (origColor, Color.white, t/flashRate);
			t += Time.deltaTime; 
			yield return null;
		}
		GetComponent<Renderer>().material.color = Color.white;
		StartCoroutine("Return");
	}

	//Bring back
	IEnumerator Return (){
		float t = 0;
		while(t < flashRate){
			GetComponent<Renderer>().material.color = Color.Lerp (Color.white, origColor, t/flashRate);
			t += Time.deltaTime; 
			yield return null;
		}
		GetComponent<Renderer>().material.color = origColor;
		StartCoroutine("Flash");
	}
}
