using UnityEngine;
using System.Collections;

public class DeselectPlayerUnitsOnClicked : MonoBehaviour {

	private UnitManager unitManager;

	public string[] objectsToActivate;

	
	void Start()
	{
		GameObject unitManagerObject = GameObject.FindGameObjectWithTag("PlayerUnitManager");
		unitManager = unitManagerObject.GetComponent<UnitManager>();
	}
	
	void Clicked()
	{
		unitManager.DeselectAllUnits();
		foreach(string tag in objectsToActivate)
		{
			GameObject [] aux;
			aux = GameObject.FindGameObjectsWithTag(tag);
			foreach(GameObject obj in aux){
				obj.SetActiveRecursively(false);
			}
		}

	}
}
