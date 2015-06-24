using UnityEngine;
using System.Collections;

public class ScreenSystem : MonoBehaviour {
	
	public GUISkin guiSkin;
	public static int zombiesKilled = 0;
	public static int humans;
	public static int sentries;
	public static int soldiers;
	public static int zombiesAlive;
	public static int points = 0;
	public static int money = 1000;
	public static int humansRescued = 0;
	string contentSoldier = "";
	string contentSentry = "";
	
	void OnGUI(){
		
		humans = CountHumans();
		sentries = CountSentries();
		soldiers = CountSoldiers();
		zombiesAlive = CountZombiesAlive();
		
		GUI.skin = guiSkin;
		GUI.Label (new Rect(10, 10, 200, 30), "Zombies Killed: " + zombiesKilled);
		GUI.Label (new Rect(10, 30, 200, 30), "Zombies Alive: " + zombiesAlive);
		GUI.Label (new Rect(170, 10, 200, 30), "Humans Alive: " + humans);
		GUI.Label (new Rect(170, 30, 200, 30), "Humans Rescued: " + humansRescued);
		GUI.Label (new Rect(350, 10, 200, 30), "Soldiers: " + soldiers);
		GUI.Label (new Rect(470, 10, 200, 30), "Sentries: " + sentries);
		GUI.Label (new Rect(590, 10, 200, 30), "Points: " + points);
		GUI.Label (new Rect(705, 10, 200, 30), "Z$ " + money);
		
		if(DragHanglerSoldier.noMoney == true && DragHanglerSoldier.timer > 0){
			contentSoldier = "You don't have enough money to buy.";
			
		}
		if (DragHanglerSoldier.timer <= 0) {
			contentSoldier = "";
		}
		
		if(DragHanglerSentry.noMoney == true && DragHanglerSentry.timer > 0){
			contentSentry = "You don't have enough money to buy.";
			
		}
		if (DragHanglerSentry.timer <= 0) {
			contentSentry = "";
		}
		
		GUI.Label (new Rect(Screen.width - 170, Screen.height/2 - 100, 200, 30), contentSoldier);
		GUI.Label (new Rect(Screen.width - 170, Screen.height/2 - 100, 200, 30), contentSentry);
	}
	
	
	public int CountHumans()
	{
		GameObject[] humansArray;
		humansArray = GameObject.FindGameObjectsWithTag("PlayerUnit");
		int count = humansArray.Length;
		return count;
	}
	
	public int CountZombiesAlive(){
		GameObject[] zombies;
		zombies = GameObject.FindGameObjectsWithTag("Enemies");
		int count = zombies.Length;
		return count;
	}
	
	public int CountSentries(){
		GameObject[] sentriesArray;
		sentriesArray = GameObject.FindGameObjectsWithTag("sentry");
		int count = sentriesArray.Length;
		return count;
	}
	
	public int CountSoldiers(){
		GameObject[] soldier;
		soldier = GameObject.FindGameObjectsWithTag("soldier");
		int count = soldier.Length;
		return count;
	}
	
}
