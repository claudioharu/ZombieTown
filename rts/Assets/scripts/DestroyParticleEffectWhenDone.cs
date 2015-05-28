using UnityEngine;
using System.Collections;

public class DestroyParticleEffectWhenDone : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(!GetComponent<ParticleSystem>().isPlaying){
			Destroy(gameObject);
		}
	}
}
