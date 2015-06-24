using UnityEngine;
using System.Collections;

public class DayAndNight : MonoBehaviour {

	public Light[] lights;
	public float dayLength = 100;

	private bool night = false;

	void makingLight(){
		foreach (Light light in lights){
			night = !night;
			light.enabled = !light.enabled;
		}
		//Alterar a velocidade dos zumbis
		Invoke ("makingLight", dayLength);
	}

	// Use this for initialization
	void Start () {
		Invoke("makingLight", dayLength);
	}
	

}
