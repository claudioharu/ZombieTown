using UnityEngine;
using System.Collections;

public class ZombieMoveAuto : MonoBehaviour
{
	
	private int cont = 0;
	private Vector3 goal;
	private float Damping = 6.0f;
	private int periodoDeAtualizacao = 10;
	public Quaternion rotation;
	public float moveSpeed = 1.0f;
	public float goalRadius = 0.1f;
	
	void Start()
	{
		cont = Random.Range(0,periodoDeAtualizacao);
		goal = transform.position;
		rotation = Quaternion.LookRotation(goal - transform.position);
		
	}
	
	Vector3 procuraAlgum(){
		Vector3 target = goal;
		float smalestDistance = float.MaxValue;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PlayerUnit")){
			Vector3 pos = obj.transform.position;
			float squareDistance = (transform.position - pos).sqrMagnitude;
			if(squareDistance<smalestDistance){
				smalestDistance = squareDistance;
				target = pos;
			}
		}
		return target;
	}
	
	void Update()
	{
		//procura algum inimigo, se acha  algum , atualiza destino
		if (cont == periodoDeAtualizacao){
			goal = procuraAlgum ();
			cont = 0;
		}
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
		cont++;
	}
	
	
}
