using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointsAtEnd : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GameObject canvas = GameObject.Find("Canvas");
		Text[] textValue = canvas.GetComponentsInChildren<Text>();
		textValue[4].text = "Total Points: " + ScreenSystem.points.ToString();
		textValue[5].text = ScreenSystem.humansRescued.ToString() + " Civilians Rescued x 200 = " + (200 * ScreenSystem.humansRescued);
		textValue[6].text = ScreenSystem.zombiesKilled.ToString() + " Zombies Killed x 100 = " + (100 * ScreenSystem.zombiesKilled);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
