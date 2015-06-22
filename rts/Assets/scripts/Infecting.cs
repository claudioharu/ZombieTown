using UnityEngine;
using System.Collections;

public class Infecting : MonoBehaviour {

	public GameObject unitType;
	public GameObject humanPosition;
	public string[] infectionTags;

//	public float infectionTime = 10.0f;


	//private int numberToInfect;

	// Use this for initialization
	void Start () {
		if(humanPosition == null)
		{
			humanPosition = gameObject;
		}
		//Invoke("InfectingHumans", infectionTime);
	}

	void OnCollisionEnter(Collision collision)
	{
		foreach (string tag in infectionTags)
		{
			if (collision.collider.tag == tag)
			{
				Destroy(collision.gameObject);
				ScreenSystem.humans -= 1;
				ScreenSystem.zombiesAlive += 1;
				Instantiate(unitType, collision.gameObject.transform.position,  unitType.transform.rotation);
				//Destroy(gameObject);
				return;
			}
		}
	}
}
