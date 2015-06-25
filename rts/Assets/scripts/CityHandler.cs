using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CityHandler : MonoBehaviour, IPointerClickHandler {
	
	public Camera mainCamera;
	public Transform [] pos;

	private int clicks = 0;

	public void OnPointerClick (PointerEventData eventData)
	{
		//print (clicks);

		if(clicks >= pos.Length)
			clicks = 0;

		mainCamera.transform.position = pos[clicks].position;
		clicks += 1;
			
	}
	
}
