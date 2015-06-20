using UnityEngine;
using System.Collections;

public class ShootSpawn : MonoBehaviour {
	
	private GameObject targetEnemy;
	
	public GameObject bullet;
    public GameObject laser;
	public LayerMask mask;
	public Transform bulletSpaw;
	
	public float fireDelay = 1.0f;
	public float radius = 1.0f;
	public float speed = 100.0f;
	
	void Start(){
		Invoke("Shoot", fireDelay);
	}
	
	// Update is called once per frame
	void Update () {

		
		Collider[] enemysArray = Physics.OverlapSphere(laser.transform.position, radius, mask);
		
		if(enemysArray.Length > 0)
			targetEnemy = enemysArray[0].gameObject;
		else
			targetEnemy = null;
	}
	
	void Shoot(){
		
		if(targetEnemy != null){
			GameObject instance = Instantiate(bullet, bulletSpaw.transform.position, bullet.transform.rotation) as GameObject;
			
			if(instance.GetComponent<Rigidbody>()){
				instance.GetComponent<Rigidbody>().AddForce((bulletSpaw.transform.forward).normalized*speed*Time.deltaTime, ForceMode.VelocityChange);
			}
		}
		
		Invoke("Shoot", fireDelay);
	}
	
}