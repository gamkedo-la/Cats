using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	Rigidbody rb;
	Collider myCol;
	void Start(){
		rb = GetComponent<Rigidbody>();
		myCol = GetComponent<Collider> ();
	}

	public void EnableGravity(){
		rb.useGravity = true;
		myCol.isTrigger = false;
	}
}
