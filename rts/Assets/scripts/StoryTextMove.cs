using UnityEngine;
using System.Collections;

public class StoryTextMove : MonoBehaviour {
	
	void FixedUpdate () {
		transform.position += transform.up * Time.deltaTime*25;
	}
}
