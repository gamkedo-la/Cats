using UnityEngine;
using System.Collections;

public class SoundWhenHitHardEnough : MonoBehaviour {

	public AudioClip[] soundsToPlay;

	public void OnCollisionEnter(Collision other){
		if (other == null || other.gameObject.tag == "Player") {
			SoundManager.instance.PlayRandClipOn (soundsToPlay, transform.position, 1.0f, transform);
		}
	}
}
