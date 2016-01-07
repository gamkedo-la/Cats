using UnityEngine;
using System.Collections;

public class ToySpinner : MonoBehaviour {

	float spinSpeed = 0.0f;
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, Time.deltaTime * spinSpeed);	
	}

	void FixedUpdate(){
		spinSpeed *= 0.97f;
	}

	public void Push(){
		spinSpeed = 520.0f;
		if (Random.Range (0, 100) < 50) {
			spinSpeed = -spinSpeed;
		}
	}
}
