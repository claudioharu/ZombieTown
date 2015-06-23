using UnityEngine;
using System.Collections;

public class TitleSongController : MonoBehaviour {
	private static TitleSongController instance = null;
	public static TitleSongController Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		}
		else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
	public void DestroySong(){
		Destroy (this.gameObject);

	}
}
