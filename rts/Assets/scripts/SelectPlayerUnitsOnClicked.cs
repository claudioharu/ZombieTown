using UnityEngine;
using System.Collections;

public class SelectPlayerUnitsOnClicked : MonoBehaviour {
	
	private UnitManager unitManager;
	public GameObject[] objectsToActivate;
	public AudioSource audioSelSoldier;
	public AudioClip clipSelSoldier;
	
	void Start()
	{
		GameObject unitManagerObject = GameObject.FindGameObjectWithTag("PlayerUnitManager");
		unitManager = unitManagerObject.GetComponent<UnitManager>();
		
		audioSelSoldier = (AudioSource) gameObject.AddComponent<AudioSource>();
		audioSelSoldier.clip = clipSelSoldier;
	}
	
	void Clicked()
	{
		audioSelSoldier.Play();
		if(!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift) ){
			//Tell the player unit manager to select this object
			
			GameObject[] aux;
			aux = GameObject.FindGameObjectsWithTag("selected");
			foreach (GameObject obj in aux)
			{
				obj.SetActiveRecursively(false);
			}
			
			foreach (GameObject obj in objectsToActivate)
			{
				obj.SetActiveRecursively(true);
			}
			unitManager.SelectSingleUnit(gameObject);
			
		}
		else{
			foreach (GameObject obj in objectsToActivate)
			{
				obj.SetActiveRecursively(true);
			}
			unitManager.SelectAdditionalUnit(gameObject);
		}
		
	}
}
