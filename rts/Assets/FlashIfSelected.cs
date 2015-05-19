using UnityEngine;
using System.Collections;



public class FlashIfSelected : MonoBehaviour {

	public float flashRate = 1.0f;
	private Color origColor; 	//Texture ?
	private Shader origShader;

	private UnitManager unitManager;

	// Use this for initialization
	void Start () {
		GameObject unitManagerObject = GameObject.FindGameObjectWithTag("PlayerUnitManager");
		unitManager = unitManagerObject.GetComponent<UnitManager>();

		origColor = GetComponent<Renderer>().material.color; //Get Texture?
		origShader = GetComponent<Renderer>().material.shader; //Get shader
	}

	void Update (){
		if(unitManager.IsSelected(gameObject)){
			GetComponent<Renderer>().material.shader = Shader.Find("Reflective/Specular");

			StartCoroutine("Flash");
		}
		else{
			StopAllCoroutines();
			GetComponent<Renderer>().material.color = origColor;
			GetComponent<Renderer>().material.shader = origShader;
		}
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
