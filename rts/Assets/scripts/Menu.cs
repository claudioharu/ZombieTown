using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public void Play(){
		Application.LoadLevel(1);
	}

	public void Quit(){
		Application.Quit();
	}
}
