using UnityEngine;
using System.Collections;

public class DayAndNight : MonoBehaviour {

	public Light[] lights;
	public float dayLength = 100;

	public static bool night = false;

	void makingLight(){
		night = !night;
		foreach (Light light in lights){
			light.enabled = !light.enabled;
		}
		//Alterar a velocidade dos zumbis
		Invoke ("makingLight", dayLength);
	}

	// Use this for initialization
	void Start () {
		night = false;
		Invoke("makingLight", dayLength);
	}
	

}
