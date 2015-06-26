using UnityEngine;
using System.Collections;

public class AudioZombie : MonoBehaviour {
	public AudioSource audioZombie;
	public AudioClip[] clipZombie;
	public static float timer;
	int clipIndex;
	string pathAudio;

	// Use this for initialization
	void Start () {
		int i;
		clipZombie = new AudioClip[24];
		audioZombie = (AudioSource) gameObject.AddComponent<AudioSource>();
		audioZombie.spatialBlend = 1;
		audioZombie.dopplerLevel = 0;
		audioZombie.minDistance = 20;
		timer = Random.Range (5.0f, 20.0f);

		for (i = 0; i < 24; i++) {
			pathAudio = "Audio/zombie-" + (i+1);
			print (pathAudio);
			clipZombie[i] = (AudioClip)Resources.Load(pathAudio);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timer < 0) {
			timer = Random.Range (5.0f, 20.0f);
			print (timer);
			PlaySound ();
		}
		timer -= Time.deltaTime;
	}

	void PlaySound(){
		clipIndex = Random.Range (0, 23);
		audioZombie.clip = clipZombie[clipIndex];
		audioZombie.Play ();


	}

}
