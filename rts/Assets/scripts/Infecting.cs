using UnityEngine;
using System.Collections;

public class Infecting : MonoBehaviour {
	
	public GameObject unitType;
	public GameObject humanPosition;
	public string[] infectionTags;
	public AudioSource audioDeathHuman;
	public AudioClip clipDeathHuman;
	
	
	//	public float infectionTime = 10.0f;
	
	
	//private int numberToInfect;
	
	
	void Start()
	{
		
		if(humanPosition == null)
		{
			humanPosition = gameObject;
		}
		//GameObject unitManagerObject = GameObject.FindGameObjectWithTag("PlayerUnitManager");
		//unitManager = unitManagerObject.GetComponent<UnitManager>();
		
		audioDeathHuman = (AudioSource) gameObject.AddComponent<AudioSource>();
		audioDeathHuman.clip = clipDeathHuman;
		audioDeathHuman.spatialBlend = 1;
		audioDeathHuman.dopplerLevel = 0;
		audioDeathHuman.minDistance = 20;
		
	}
	
	// Use this for initialization
	
	void OnCollisionEnter(Collision collision)
	{
		foreach (string tag in infectionTags)
		{
			if (collision.collider.tag == tag)
			{
				//	unitManager.DeselectAllUnits();
				audioDeathHuman.Play ();
				Destroy(collision.gameObject);
				if(tag != "soldier"){
					
					ScreenSystem.humans -= 1;
					ScreenSystem.humansKilled += 1;
				}
				
				ScreenSystem.zombiesAlive += 1;
				Instantiate(unitType, collision.gameObject.transform.position,  unitType.transform.rotation);
				//Destroy(gameObject);
				return;
			}
		}
	}
}
