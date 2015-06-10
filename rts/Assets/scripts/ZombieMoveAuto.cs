using UnityEngine;
using System.Collections;

public class ZombieMoveAuto : MonoBehaviour
{
    protected Animator animacao;

    private NavMeshAgent agent;
	private int cont = 0;
	private Vector3 goal;
	private float Damping = 6.0f;	
	private int periodoDeAtualizacao = 10;


	public Quaternion rotation;
	public float moveSpeed = 1.0f;
	public float goalRadius = 0.1f;
	public bool temMovimento = false;
	public bool perseguindo = false;
	public float visionThreshhold = 100;
	public float FOV = 45;
	
	void Start()
	{	
		animacao = GetComponent<Animator> ();
        agent = GetComponent<NavMeshAgent>();

		cont = Random.Range(0,periodoDeAtualizacao);
		goal = transform.position;
		rotation = Quaternion.LookRotation(goal - transform.position);
		
	}
	bool visible(Vector3 pos){
		Vector3 newDirection = pos - transform.position;
		 // the vector that we want to measure an angle from
		Vector3 referenceForward = Vector3.forward;/* some vector that is not Vector3.up */
		return Vector3.Angle(newDirection, referenceForward)<FOV;
		/*/ the vector perpendicular to referenceForward (90 degrees clockwise)
		// (used to determine if angle is positive or negative)
		Vector3 referenceRight= Vector3.Cross(Vector3.up, referenceForward);
 
		// Get the angle in degrees between 0 and 180
		float angle = Vector3.Angle(newDirection, referenceForward);
 
		// Determine if the degree value should be negative.  Here, a positive value
		// from the dot product means that our vector is on the right of the reference vector   
		// whereas a negative value means we're on the left.
		float sign = Mathf.Sign(Vector3.Dot(newDirection, referenceRight));
 
		float finalAngle = sign * angle;
		return !(finalAngle>FOW || finalAngle < -FOV );*/
	}
	Vector3 procuraAlgum(){
		Vector3 target = goal;
		perseguindo = false;
		float smalestDistance = float.MaxValue;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PlayerUnit")){
			Vector3 pos = obj.transform.position;
			float squareDistance = (transform.position - pos).sqrMagnitude;
			if(visible(pos) && squareDistance<smalestDistance && squareDistance < visionThreshhold){
				smalestDistance = squareDistance;
				target = pos;
				temMovimento = true;
				perseguindo = true;
			}
		}
		return target;
	}
	//Vector3 passoRandom(){
	//	Vector3 resposta = transform.position + Random.Range(-180,180)
	//}
	void Update()
	{
        
		//procura algum inimigo, se acha  algum , atualiza destino
		if (cont == periodoDeAtualizacao){
			goal = procuraAlgum ();
			cont = 0;
		}
		//Move towards our goal
		/*transform.position += (goal - transform.position).normalized*moveSpeed*Time.deltaTime;
		*/transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
        
		/*if(perseguindo)*/agent.SetDestination(goal);
		/*else{
			agent.Stop();
			agent.velocity=Vector3.zero;
		}*/
        //else agent.SetDestination(transform.position);
		if(temMovimento){
			if ( (goal - transform.position).magnitude < 1.0f){
				temMovimento = false;
				animacao.SetFloat("veloc",0);
			}
			else{
				rotation = Quaternion.LookRotation(goal - transform.position);
				animacao.SetFloat("veloc", 10*moveSpeed);
			}
		}
		cont++;
	}
	
	
}
