using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class DragHanglerSoldier : MonoBehaviour, IPointerClickHandler {
	
	public GameObject unitType;
	
	
	private bool creatingUnit = false;
	private Vector3 dist;
	private float posX, posY;
	public static bool noMoney = false;
	public static float timer = 0.0f;
	public Transform positionSoldier;

	public GameObject effectObject;

	public void OnPointerClick (PointerEventData eventData)
	{
		print("eu");
		
		dist = Camera.main.WorldToScreenPoint(unitType.transform.position);
		
		creatingUnit = true;
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
		
		if (ScreenSystem.money < 500) {
			creatingUnit = false;
			print ("You don't have enough money to buy.");
			noMoney = true;
			timer = 3.0f;
		}
		else{
			noMoney = false;
		}
	}
	
	public void FixedUpdate()
	{
		timer -= Time.deltaTime;
		if(timer <= 0){
			timer = 0;
		}
		//print (creatingUnit);
		if(creatingUnit){
			
			//if(Input.GetMouseButton(1)){
				
				Vector3 curPos = new Vector3(Input.mousePosition.x , Input.mousePosition.y , dist.z); 
				Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
				
				
				Instantiate(unitType, positionSoldier.position, unitType.transform.rotation);
				Instantiate(effectObject, positionSoldier.position, effectObject.transform.rotation);
				ScreenSystem.soldiers += 1;
				ScreenSystem.money -= 500;
				if (ScreenSystem.money < 0) {
					ScreenSystem.money = 0;
				}
				
				creatingUnit = false;
			//}
		}
	}
}

