using UnityEngine;
using System.Collections;

public class CatControllerBackup : MonoBehaviour {
	public float catSpeed = 10.0f;
	public float catJumpForce = 100.0f;

	Vector3 moveVect; 
	Rigidbody rb;
	RaycastHit hit;
	float distanceToGround;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		distanceToGround = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		moveVect = Input.GetAxis ("Horizontal") * Vector3.right + Input.GetAxis ("Vertical") * Vector3.forward;
		float moveVectLength = moveVect.magnitude;
		if (moveVectLength > 1.0f) {
			moveVect.Normalize();
		}
		// transform.position += moveVect * Time.deltaTime * catSpeed;

		if (moveVectLength > 0.2f) {
			transform.LookAt(transform.position + moveVect);
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (Physics.Raycast(transform.position, -Vector3.up, out hit)){
				distanceToGround = hit.distance;
			}
			if(distanceToGround < 0.6f){
				rb.AddForce(Vector3.up * catJumpForce);
			}

		}
		if (Input.GetKeyUp (KeyCode.Space) && rb.velocity.y > 0.0f) {
			Vector3 cancelledY = rb.velocity;
			cancelledY.y = 0.0f;
			rb.velocity = cancelledY;
		}
	}

	void FixedUpdate(){
		float wasY = rb.velocity.y;
		Vector3 preservedY = moveVect * catSpeed * Time.fixedDeltaTime;
		preservedY.y = wasY;
		rb.velocity = preservedY;
	}
}
