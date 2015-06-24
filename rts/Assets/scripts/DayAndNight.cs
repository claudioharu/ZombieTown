using UnityEngine;
using System.Collections;

public class DayAndNight : MonoBehaviour {

	public Light[] lights;
	public string[] enemiesTag;

	private bool night = false;

	void makingLight(){
		foreach (Light light in lights){
			night = !night;
			light.enabled = !light.enabled;
		}
		//Alterar a velocidade dos zumbis
		Invoke ("makingLight", 2);
	}

	// Use this for initialization
	void Start () {
		Invoke("makingLight", 2);
	}
	

}
