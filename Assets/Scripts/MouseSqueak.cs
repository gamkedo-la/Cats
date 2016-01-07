using UnityEngine;
using System.Collections;

public class MouseSqueak : MonoBehaviour {

	AudioSource squeak;
	float squeakInterval = 4.0f;
	// Use this for initialization
	void Start () {
		squeak = GetComponent<AudioSource> ();
		StartCoroutine (Squeak ());
	}

	IEnumerator Squeak(){
		yield return new WaitForSeconds (squeakInterval);
		squeak.Play ();
		squeakInterval = Random.Range (3.0f, 10.0f);
		StartCoroutine (Squeak ());
	}
}
