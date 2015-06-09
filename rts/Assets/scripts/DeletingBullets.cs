using UnityEngine;
using System.Collections;

public class DeletingBullets : MonoBehaviour {

	public float TimeToDelete = 2.0f;

	// Use this for initialization
	void Start () {
		Invoke("DeletingBullet", TimeToDelete);
	}

	//Deleting after 2 seconds
	void DeletingBullet(){

		Destroy(gameObject);

	}
}
