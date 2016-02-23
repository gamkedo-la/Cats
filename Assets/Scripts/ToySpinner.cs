using UnityEngine;
using System.Collections;

public class ToySpinner : MonoBehaviour {

	public Transform ropeEnd;
	float spinSpeed = 0.0f;
	float sideOffset = 0.0f;
	Vector3 startPosEndRope;

	void Start(){
		startPosEndRope = ropeEnd.localPosition;
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, Time.deltaTime * spinSpeed);
		ropeEnd.localPosition = startPosEndRope + transform.right * sideOffset;
	}

	void FixedUpdate(){
		spinSpeed *= 0.97f;
		sideOffset *= 0.99f;
	}

	public void Push(){
		spinSpeed = 520.0f;
		if (Random.Range (0, 100) < 50) {
			spinSpeed = -spinSpeed;
			sideOffset += 0.3f;
		} else {
			sideOffset += -0.3f;
		}
	}
}
