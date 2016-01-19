using UnityEngine;
using System.Collections;


public class Gravity : MonoBehaviour {

    public int pointValue;

    Rigidbody rb;
	Collider myCol;
	void Start(){
		rb = GetComponent<Rigidbody>();
		myCol = GetComponent<Collider> ();
	}

	public void EnableGravity(){
		rb.useGravity = true;
		myCol.isTrigger = false;
        ScoreManager.AddPoints(pointValue);
	}
}
