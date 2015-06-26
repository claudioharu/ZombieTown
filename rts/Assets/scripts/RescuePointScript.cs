using UnityEngine;
using System.Collections;

public class RescuePointScript : MonoBehaviour {

	public string[] suviversTags;

	public AudioSource audioSaveHuman;
	public AudioClip clipSaveHuman;

	void Start(){
		audioSaveHuman = (AudioSource) gameObject.AddComponent<AudioSource>();
		audioSaveHuman.clip = clipSaveHuman;
	}

	void OnCollisionEnter(Collision collision)
	{
		//print ("passei");
		foreach (string tag in suviversTags)
		{
			//atualizar o contador de sobreviventes
			if (collision.collider.tag == tag)
			{
				audioSaveHuman.Play();
				//print ("destrui");
				//ScreenSystem.zombiesKilled += 1;
				Destroy(collision.gameObject);
				ScreenSystem.humansRescued += 1;
				ScreenSystem.points += 200;
				ScreenSystem.money += 150;
				//Destroy(gameObject);
				return;
			}
		}
	}
}
