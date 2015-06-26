using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour {

	public Transform spawnPos;
	public GameObject zombie;
	public float birthRate = 10f;

	void Start () {
		Invoke("ZombiesBirth", birthRate);
	}

	void ZombiesBirth(){
		Instantiate(zombie, spawnPos.position, spawnPos.rotation);
		Invoke("ZombiesBirth", birthRate);
	}
}
