using UnityEngine;
using System.Collections;

public class IsoCam : MonoBehaviour {

	Vector3 cameraLagLoc;
	public float camUpDistance = 10.0f;
	public float camBackDistance = -10.0f;
	// Use this for initialization
	void Start () {
		cameraLagLoc = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 groundUnderCat = cameraLagLoc;
		groundUnderCat.y = 1.0f;
		Camera.main.transform.position = groundUnderCat + Vector3.up * camUpDistance + Vector3.forward * camBackDistance;
		Camera.main.transform.LookAt (groundUnderCat);
	}

	void FixedUpdate(){
		float lagK = 0.85f;
		cameraLagLoc = cameraLagLoc * lagK + transform.position * (1.0f - lagK);
	}
}
