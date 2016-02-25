using UnityEngine;
using System.Collections;

public class PlaySoundWhenCatEnters : MonoBehaviour {
	public AudioClip[] soundArray;

	void OnTriggerEnter(Collider whatEntered) {
		if(whatEntered.name.Contains("Cat")) {
			SoundManager.instance.PlayClipOn(soundArray[ Random.Range(0,soundArray.Length) ], Camera.main.transform.position, 1, Camera.main.transform);
		}	
	}
}
