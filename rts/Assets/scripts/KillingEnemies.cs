using UnityEngine;
using System.Collections;

public class KillingEnemies : MonoBehaviour {
	
	public string[] annihilationTags;
	
	private HpZombies hpZombie;
	
	public AudioSource audioHitZombie;
	public AudioClip clipHitZombie;
	
	void Start(){
		audioHitZombie = (AudioSource) gameObject.AddComponent<AudioSource>();
		audioHitZombie.clip = clipHitZombie;
		audioHitZombie.spatialBlend = 1;
		audioHitZombie.dopplerLevel = 0;
		audioHitZombie.minDistance = 20;
	}
	
	void OnCollisionEnter(Collision collision)
	{
		//print("aki");
		foreach (string tag in annihilationTags)
		{
			//print (tag);
			if (collision.collider.tag == tag)
			{
				hpZombie = collision.collider.gameObject.GetComponent<HpZombies>();
				hpZombie.hp -= 50;
				//Toca audio de dano no zumbi
				audioHitZombie.Play();
				
				
				//print (collision.collider.tag);
				if(tag=="Enemies" && hpZombie.hp <= 0){
					ScreenSystem.zombiesKilled += 1;
					ScreenSystem.points += 100;
					ScreenSystem.money += 100;
					Destroy(collision.gameObject);
					//print ("vida menor que 0 !!! matei =3");
				}
				
				
				Destroy(gameObject);
				return;
			}
		}
	}
}