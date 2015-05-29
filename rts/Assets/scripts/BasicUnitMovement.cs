using UnityEngine;
using System.Collections;

public class BasicUnitMovement : MonoBehaviour
{

	private Vector3 goal;
	private float Damping = 6.0f;
	
	public Quaternion rotation;
	public float moveSpeed = 1.0f;
	public float goalRadius = 0.1f;
	
	void Start()
	{
		goal = transform.position;
		rotation = Quaternion.LookRotation(goal - transform.position);
		
	}
	
	public void MoveOrder(Vector3 newGoal)
	{
		goal = newGoal;
		
	}
	
	void Update()
	{
		//Move towards our goal
		transform.position += (goal - transform.position).normalized*moveSpeed*Time.deltaTime;
		
		
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
		rotation = Quaternion.LookRotation(goal - transform.position);
		
		foreach(Collider obj in Physics.OverlapSphere(goal,goalRadius))
		{
			if(obj.gameObject == gameObject)
			{
				goal = transform.position;
				rotation = transform.rotation;
			}
		}
	}


}