using UnityEngine;
using System.Collections;

public class SelectPlayerUnitsOnClicked : MonoBehaviour {

	private UnitManager unitManager;
	
	void Start()
	{
		GameObject unitManagerObject = GameObject.FindGameObjectWithTag("PlayerUnitManager");
		unitManager = unitManagerObject.GetComponent<UnitManager>();
	}

	void Clicked()
	{
		if(!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift) ){
			//Tell the player unit manager to select this object
			unitManager.SelectSingleUnit(gameObject);
		}
		else{
			unitManager.SelectAdditionalUnit(gameObject);
		}
		


	}
}
