using UnityEngine;
using System.Collections;

public class BasicUnitMovement : MonoBehaviour {

	public float goalRadius = 0.01f;
	public float moveSpeed = 1.0f;
	private Vector3 goal;

	public void MoveOrder(Vector3 newGoal){
		goal = newGoal;
	}
	
	void Start(){
		goal = transform.position;
	}

	void Update()
	{
		// Move towards our goal
		transform.position += (goal - transform.position).normalized*moveSpeed*Time.deltaTime;

		foreach(Collider obj in Physics.OverlapSphere(goal, goalRadius))
		{
			if(obj.gameObject == gameObject){
				transform.position = goal;
			}
		}

	}

}
