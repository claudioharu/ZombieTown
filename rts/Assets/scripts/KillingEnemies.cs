using UnityEngine;
using System.Collections;

public class KillingEnemies : MonoBehaviour {
	
	public string[] annihilationTags;
	
	void OnCollisionEnter(Collision collision)
	{
		print("aki");
		foreach (string tag in annihilationTags)
		{
			print (tag);
			if (collision.collider.tag == tag)
			{
				//print (collision.collider.tag);
				if(tag=="Enemies"){
					ScreenSystem.zombiesKilled += 1;
					ScreenSystem.points += 100;
					ScreenSystem.money += 100;
				}
				Destroy(collision.gameObject);
				Destroy(gameObject);
				return;
			}
		}
	}
}