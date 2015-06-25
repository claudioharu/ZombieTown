using UnityEngine;
using System.Collections;

public class Commands : MonoBehaviour {


	public static bool shoot = true;
	

	// Update is called once per frame
	public void Enable () {
		shoot = true;
	}

	public void Disable () {
		shoot = false;
	}
}
