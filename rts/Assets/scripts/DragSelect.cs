using UnityEngine;
using System.Collections;

public class DragSelect : MonoBehaviour
{

    public GameObject selector;
    private GameObject selectorInstance;
    private Vector3 corner;
    private UnitManager unitManager;

    void Start()
    {
        GameObject unitManagerObject = GameObject.FindGameObjectWithTag("PlayerUnitManager");
        unitManager = unitManagerObject.GetComponent<UnitManager>();
    }
    void OnMouseDown()
    {

        //Raycast to determine position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit inf;

        //1 default layer
        Physics.Raycast(ray, out inf, Mathf.Infinity, 1);

        corner = inf.point;
        //Instantiate selector cube with proper position
        selectorInstance = Instantiate(selector, corner, selector.transform.rotation) as GameObject;

    }

    void OnMouseDrag()
	{
	    //Raycast to determine position
	    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	    RaycastHit inf;
	    //1 default layer
	    Physics.Raycast(ray, out inf, Mathf.Infinity, 1);

	    //Resize selector cube with new position
	    Vector3 resizeVector = inf.point - corner;
	    Vector3 newScale = selectorInstance.transform.localScale;

	    newScale.x = resizeVector.x;
	    newScale.z = -resizeVector.z;
	    selectorInstance.transform.localScale = newScale;

              

    }

    void OnMouseUp()
    {
        //destroy selector cube
        Destroy(selectorInstance);
    }
}
