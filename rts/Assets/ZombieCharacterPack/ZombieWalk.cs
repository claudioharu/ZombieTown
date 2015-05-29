using UnityEngine;
using System.Collections;

public class ZombieWalk : MonoBehaviour {
	protected Animator animacao;
	// Use this for initialization
	void Start () {
		animacao = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		animacao.SetFloat("veloc", 3*Input.GetAxis("Vertical"));
	}
}
