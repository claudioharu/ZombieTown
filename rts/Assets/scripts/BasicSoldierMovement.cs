using UnityEngine;
using System.Collections;

public class BasicSoldierMovement : MonoBehaviour {
	
	protected Animation animacao;
	
	private NavMeshAgent agent;
	private Vector3 goal;
	private float Damping = 6.0f;
	
	public Quaternion rotation;
	public float moveSpeed = 1.0f;
	public float goalRadius = 0.1f;	
	public bool temMovimento = false;
	
	public AudioSource audioTakeOrders;
	public AudioClip clipTakeOrders;
	
	public AudioSource audioWalk;
	public AudioClip clipWalk;
	
	
	
	// Use this for initialization
	void Start () {
		animacao = GetComponent<Animation> ();
		agent = GetComponent<NavMeshAgent>();
		
		goal = transform.position;
		
		audioTakeOrders = (AudioSource) gameObject.AddComponent<AudioSource>();
		audioTakeOrders.clip = clipTakeOrders;
		audioTakeOrders.spatialBlend = 1;
		audioTakeOrders.dopplerLevel = 0;
		audioTakeOrders.minDistance = 20;
		
		audioWalk = (AudioSource) gameObject.AddComponent<AudioSource>();
		audioWalk.clip = clipWalk;
		audioWalk.loop = true;
		audioWalk.spatialBlend = 1;
		audioWalk.dopplerLevel = 0;
		audioWalk.minDistance = 20;
		
		//rotation = Quaternion.LookRotation(goal - transform.position);
	}
	
	public void MoveOrder(Vector3 newGoal)
	{
		goal = newGoal;
		temMovimento = true;
		audioTakeOrders.Play();
		audioWalk.Play ();
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		agent.SetDestination(goal);
		
		//Move towards our goal
		/*transform.position += (goal - transform.position).normalized*moveSpeed*Time.deltaTime;
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
		*/
		if(temMovimento){
			if ( (goal - transform.position).magnitude < 1.0f){
				temMovimento = false;
				//animacao.SetFloat("speed",0);
				animacao.Play("soldierIdle");
				
			}
			else{
				rotation = Quaternion.LookRotation(goal - transform.position);
				//animacao.SetFloat("speed", 10*moveSpeed);
				animacao.Play("soldierRun");
				
			}
		}
		else{
			if(audioWalk.isPlaying){
				audioWalk.Stop ();
			}
		}
	}
}
