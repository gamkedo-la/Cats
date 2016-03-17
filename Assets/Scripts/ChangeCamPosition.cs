using UnityEngine;
using System.Collections;

public class ChangeCamPosition : MonoBehaviour {

	static CatCam catCam;
	Transform cameraPos;
	bool changeCamPos = false;
	// Use this for initialization
	void Start () {
		cameraPos = transform.GetChild (0);
		if (catCam == null) {
			catCam = Camera.main.GetComponent<CatCam> ();
		}
	}

	void OnTriggerEnter(Collider other){
//		Debug.Log ("Entered Camera, target: " + name + " " + other.name);
		if(other.gameObject.layer == LayerMask.NameToLayer("ClickTester")){
			changeCamPos = true;
		}
		if(other.gameObject.layer == LayerMask.NameToLayer("Cat") && changeCamPos == true){
			catCam.setGoal (cameraPos);
		}

	}

	void OnTriggerExit(Collider other){
//		if(other.gameObject.layer == LayerMask.NameToLayer("Cat")){
//
//		}
		if(other.gameObject.layer == LayerMask.NameToLayer("ClickTester")){
			changeCamPos = false;
			catCam.reset ();
		}
	}
}
