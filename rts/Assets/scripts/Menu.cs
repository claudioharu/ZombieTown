using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public void Play(){
		Application.LoadLevel(1);
	}

	public void EnterTown(){
		TitleSongController.Instance.DestroySong();
		Application.LoadLevel(2);
	}

	public void Back(){
		Application.LoadLevel("menu");
	}
	
	public void Quit(){
		Application.Quit();
	}
}
