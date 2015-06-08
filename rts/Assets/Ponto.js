#pragma strict

var Ponto: Transform;
var AuxPosicaoNavMesh: NavMeshAgent;
var animacao: Animator;

var MoveSpeed: float;

function Start () {
	animacao = GetComponent("Animator");
	AuxPosicaoNavMesh = transform.GetComponent("NavMeshAgent");
	animacao.SetFloat("speed",0);
}

function Update () {
	AuxPosicaoNavMesh.destination = Ponto.position;
	animacao.SetFloat("speed", 100*MoveSpeed);
}