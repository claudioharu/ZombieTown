using UnityEngine;
using System.Collections;

public class MoveSelectedUnitsOnRightClick : MonoBehaviour {

	public GameObject moveEffectObject;
	private UnitManager unitManager;

	void Start(){
		GameObject unitManagerObject = GameObject.FindGameObjectWithTag("PlayerUnitManager");
		unitManager = unitManagerObject.GetComponent<UnitManager>();
	}

	void RightClicked(Vector3 clickPosition){
		bool unitsSelected = false;
		foreach(GameObject unit in  unitManager.GetSelectedUnits()){
			unitsSelected = true;
			unit.SendMessage("MoveOrder", clickPosition);
		}
		if(unitsSelected){
			Instantiate(moveEffectObject, clickPosition, moveEffectObject.transform.rotation);
		}
	}
}
