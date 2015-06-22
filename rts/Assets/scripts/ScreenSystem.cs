using UnityEngine;
using System.Collections;

public class ScreenSystem : MonoBehaviour {

	public GUISkin guiSkin;
	public static int zombiesKilled = 0;
	public static int humans;
	public static int sentries;
	public static int soldiers;
	public static int zombiesAlive;

	void OnGUI(){

		humans = CountHumans();
		sentries = CountSentries();
		soldiers = CountSoldiers();
		zombiesAlive = CountZombiesAlive();

		GUI.skin = guiSkin;
		GUI.Label (new Rect(10, 10, 200, 30), "Zombies Killed: " + zombiesKilled);
		GUI.Label (new Rect(150, 10, 200, 30), "Sentries: " + sentries);
		GUI.Label (new Rect(250, 10, 200, 30), "Humans: " + humans);
		GUI.Label (new Rect(340, 10, 200, 30), "Soldiers: " + soldiers);
		GUI.Label (new Rect(440, 10, 200, 30), "Zombies Alive: " + zombiesAlive);

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
