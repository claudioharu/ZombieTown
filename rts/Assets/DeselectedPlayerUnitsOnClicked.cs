using UnityEngine;
using System.Collections;

public class DeselectedPlayerUnitsOnClicked : MonoBehaviour {

	private UnitManager unitManager;
	
	void Start(){
		GameObject unitManagerObject = GameObject.FindGameObjectWithTag("PlayerUnitManager");
		unitManager = unitManagerObject.GetComponent<UnitManager>();
	}

	void Clicked()
	{
		unitManager.DeselectAllUnits();
	}
	

}
