using UnityEngine;
using System.Collections;

public class KillingEnemies : MonoBehaviour {
	
	public string[] annihilationTags;

	private HpZombies hpZombie;
	
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