using UnityEngine;
using System.Collections;

public class CatCam : MonoBehaviour {

	public Transform cameraDefaultPos;
	Transform goalPos;
	// Use this for initialization
	void Start () {
		reset ();
	}

	public void reset(){
		goalPos = cameraDefaultPos;
	}

	public void setGoal(Transform goal){
		goalPos = goal;
	}

	void FixedUpdate(){
		float lagK = 0.06f;
		float rotLag = lagK;
		transform.position = goalPos.transform.position * lagK + transform.position * (1.0f - lagK);
		transform.rotation = Quaternion.Slerp (transform.rotation, goalPos.transform.rotation, rotLag);
	}
}
