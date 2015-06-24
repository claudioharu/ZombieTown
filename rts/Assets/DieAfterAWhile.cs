using UnityEngine;
using System.Collections;

public class DieAfterAWhile : MonoBehaviour {

	public float TimeToDelete = 0.1f;

	// Use this for initialization
	void Start () {
		Invoke("DeletingBullet", TimeToDelete);
	}

	//Deleting after 2 seconds
	void DeletingSelf(){

		Destroy(gameObject);

	}
}
