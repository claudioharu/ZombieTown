using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHanglerSentry : MonoBehaviour, IPointerClickHandler {
	
	public GameObject unitType;
	
	
	private bool creatingUnit = false;
	private Vector3 dist;
	private float posX, posY;
	public static bool noMoney = false;
	public static float timer = 0.0f;
	
	public void OnPointerClick (PointerEventData eventData)
	{
		//print (Input.mousePosition);
		//pos = new Vector3(0.0f,0.0f, 10.0f); 
		dist = Camera.main.WorldToScreenPoint(unitType.transform.position);
		
		creatingUnit = true;
		posX = Input.mousePosition.x - dist.x;
		posY = Input.mousePosition.y - dist.y;
		
		if (ScreenSystem.money < 1000) {
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
		print (creatingUnit);
		if(creatingUnit){
			if(Input.GetMouseButton(1)){
				
				Vector3 curPos = new Vector3(Input.mousePosition.x , Input.mousePosition.y , dist.z); 
				Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
				
				
				Instantiate(unitType, worldPos, unitType.transform.rotation);
				ScreenSystem.sentries += 1;
				ScreenSystem.money -= 1000;
				if (ScreenSystem.money < 0) {
					ScreenSystem.money = 0;
				}
				creatingUnit = false;
			}
		}
	}
}
