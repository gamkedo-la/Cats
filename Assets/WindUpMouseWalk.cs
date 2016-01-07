using UnityEngine;
using System.Collections;

public class WindUpMouseWalk : MonoBehaviour {
	Rigidbody rb;
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(rb.velocity.magnitude < 0.4f) {
			rb.AddForce(transform.up * 15.0f);
			rb.AddTorque(transform.right * -2.0f);
		}
	}
}
