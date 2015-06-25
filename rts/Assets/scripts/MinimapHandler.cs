using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class MinimapHandler : MonoBehaviour, IPointerClickHandler {

	public Camera mainCamera;
	public Transform pos;

	public void OnPointerClick (PointerEventData eventData)
	{
		//print ("map");
		mainCamera.transform.position = pos.position;
	}
	
}
