using UnityEngine;
using System.Collections;

public class ZombieRandomMovement : MonoBehaviour {

	protected Animator animacao;

	private int random;
	private NavMeshAgent agent;
	private GameObject [] array;
	private float Damping = 6.0f;
	private Quaternion rotation;


	public ZombieMoveAuto obj;
	public float moveSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		animacao = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent>();
		array = GameObject.FindGameObjectsWithTag("WayPoint");
		random = Random.Range(0, array.Length - 1);
		//rotation = Quaternion.LookRotation(array[random].transform.position - transform.position);
		animacao.SetFloat("speed",0);
	}
	
	// Update is called once per frame
	void Update () {
		float dist = agent.remainingDistance; 

		//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
		print (random);

		if(!obj.perseguindo)
		{
			if (dist != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0){
				random = Random.Range(0, array.Length - 1);
				animacao.SetFloat("veloc", 0);
				//print ("eu");
				//agent.Stop();
			}
			//rotation = Quaternion.LookRotation(array[random].transform.position - transform.position);
			animacao.SetFloat("veloc", 10*moveSpeed);
			agent.SetDestination(array[random].transform.position);
			//agent.updatePosition = true;
			//agent.updateRotation = true;
		}
	}
}
