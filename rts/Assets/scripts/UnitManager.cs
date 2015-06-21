using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UnitManager : MonoBehaviour {

	public List<GameObject> selectedUnits;

	// Use this for initialization
	void Start () {
		selectedUnits.Clear();
	}

	//Checking selected units
	public bool IsSelected(GameObject unit){
		if(selectedUnits.Contains(unit)){
			return true;
		}
		else{
			return false;
		}
	}

	public void SelectSingleUnit(GameObject unit){
		selectedUnits.Clear();
		selectedUnits.Add(unit);
		//Debug.Log(selectedUnits);
	}

	public void SelectAdditionalUnit(GameObject unit){
		selectedUnits.Add(unit);
	}

	public void DeselectAllUnits(){
		selectedUnits.Clear();
	}

	public List<GameObject> GetSelectedUnits(){
		return selectedUnits;
	}
}
