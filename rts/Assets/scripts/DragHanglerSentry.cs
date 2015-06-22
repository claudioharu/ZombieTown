using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHanglerSentry : MonoBehaviour, IPointerClickHandler {

	public GameObject unitType;


	private bool creatingUnit = false;
	private Vector3 dist;
	private float posX, posY;

	
	public void OnPointerClick (PointerEventData eventData)
	{
		//print (Input.mousePosition);
		//pos = new Vector3(0.0f,0.0f, 10.0f); 
		dist = Camera.main.WorldToScreenPoint(unitType.transform.position);

		creatingUnit = true;
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
	}

	public void FixedUpdate()
	{

		print (creatingUnit);
		if(creatingUnit){
			if(Input.GetMouseButton(1)){

				Vector3 curPos = new Vector3(Input.mousePosition.x , Input.mousePosition.y , dist.z); 
				Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);


				Instantiate(unitType, worldPos, unitType.transform.rotation);
				ScreenSystem.sentries += 1;

				creatingUnit = false;
			}
		}
	}
}
