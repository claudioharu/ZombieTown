using UnityEngine;
using System.Collections;

public class BasicUnitMovementZombie : MonoBehaviour {
	protected Animator animacao;
	private Vector3 goal;
	private float Damping = 6.0f;
	
	public Quaternion rotation;
	public float moveSpeed = 1.0f;
	public float goalRadius = 0.1f;

	public bool temMovimento = false;

	// Use this for initialization
	void Start () {
		animacao = GetComponent<Animator> ();

		goal = transform.position;
		//rotation = Quaternion.LookRotation(goal - transform.position);
	}

	public void MoveOrder(Vector3 newGoal)
	{
		goal = newGoal;
		temMovimento = true;
		
	}

	// Update is called once per frame
	void Update () {

		//Move towards our goal
		transform.position += (goal - transform.position).normalized*moveSpeed*Time.deltaTime;
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);

		if(temMovimento){
			if ( (goal - transform.position).magnitude < 3.0f){
				temMovimento = false;
				animacao.SetFloat("veloc",0);
			}
			else{
				rotation = Quaternion.LookRotation(goal - transform.position);
				animacao.SetFloat("veloc", 10*moveSpeed);
			}
		}
	}
}
