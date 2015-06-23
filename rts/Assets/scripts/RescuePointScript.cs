using UnityEngine;
using System.Collections;

public class RescuePointScript : MonoBehaviour {

	public string[] suviversTags;
	
	void OnCollisionEnter(Collision collision)
	{
		//print ("passei");
		foreach (string tag in suviversTags)
		{
			//atualizar o contador de sobreviventes
			if (collision.collider.tag == tag)
			{
				//print ("destrui");
				//ScreenSystem.zombiesKilled += 1;
				Destroy(collision.gameObject);
				//Destroy(gameObject);
				return;
			}
		}
	}
}
