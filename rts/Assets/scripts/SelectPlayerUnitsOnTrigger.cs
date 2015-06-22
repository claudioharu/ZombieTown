using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectPlayerUnitsOnTrigger : MonoBehaviour
{
	public string[] tags;
	public GameObject[] objectsToActivate;

	private UnitManager unitManager;
	private bool willSelect = false;
	
	void Start()
	{
		
		GameObject unitManagerObject = GameObject.FindGameObjectWithTag("PlayerUnitManager");
		unitManager = unitManagerObject.GetComponent<UnitManager>();
	}
	
	void OnTriggerEnter(Collider col)
	{
		foreach (string tag in tags)
		{
			if (col.tag == tag)
			{
				willSelect = true;
				unitManager.SelectAdditionalUnit(gameObject);

				foreach(GameObject obj in objectsToActivate)
				{
					obj.SetActiveRecursively(true);
				}
				
				return;
			}
		}
	}

    void OnTriggerExit(Collider col)
    {
        foreach (string tag in tags)
        {
            if (col.tag == tag)
            {
                willSelect = false;
				foreach(GameObject obj in objectsToActivate)
				{
					obj.SetActiveRecursively(false);
				}
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (willSelect)
            {
                willSelect = false;

                unitManager.SelectAdditionalUnit(gameObject);
            }
        }
    }

}
