using UnityEngine;
using System.Collections;

public class CatController : MonoBehaviour {
	public float catSpeed = 10.0f;
	public float leapSpeed = 20.0f;
	public float catJumpForce = 100.0f;
	public float closeEnoughToTarget = 0.5f;
	public float whiskerLength = 0.8f;
	public GameObject catGoal;

	Vector3 targetMovePoint;
	Vector3 targetWayPoint;
	Rigidbody rb;
	Collider col;
	bool jumping;
	float jumpHeightTester;
	int ignoreClickTesterLayer;

	// Use this for initialization
	void Start () {
		targetMovePoint = transform.position;
		rb = GetComponent<Rigidbody> ();
		col = GetComponent<Collider> ();
		jumping = false;
		jumpHeightTester = 4.0f;
		ignoreClickTesterLayer = ~LayerMask.GetMask ("ClickTester");
	}

	void MouseTarget(){
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast (camRay, out floorHit, 5000.0f)) {

//			targetMovePoint = floorHit.point;
			catGoal.transform.position = floorHit.point;
			StartCoroutine(WayPointSanityTest());
		}
	}

	IEnumerator WayPointSanityTest(){
		yield return new WaitForSeconds (0.1f);
		Ray wayPoint = new Ray (catGoal.transform.position, -Vector3.up);
		RaycastHit wphinfo;
		if (Physics.Raycast (wayPoint, out wphinfo, 2.0f)) {
			targetMovePoint = wphinfo.point;
		} else {
			targetMovePoint = transform.position;
			Debug.Log("Invalid input was rejected because the point was too high from the ground"); 
		}
	}

	void StartJump(Vector3 waypoint){
		jumping = true;
		col.enabled = false;
		targetWayPoint = waypoint + Vector3.up * 0.5f;  // how far above surface to jump to
	}

	void EndJump(){
		jumping = false;
		transform.rotation = Quaternion.identity;
		rb.velocity = Vector3.zero;
		col.enabled = true;
	}

	void MoveToTarget(){
		float distToTarget = Vector3.Distance (transform.position, targetMovePoint);
		if (jumping) {
			float distToWayPoint = Vector3.Distance (transform.position, targetWayPoint);
			if (distToWayPoint > closeEnoughToTarget){
				transform.LookAt(targetWayPoint);
				rb.velocity = transform.forward * leapSpeed;
			} else {
				EndJump();
			}
		} else if (distToTarget > closeEnoughToTarget) {
			Vector3 catPlaneClicked = targetMovePoint;
			catPlaneClicked.y = transform.position.y;
			transform.LookAt (catPlaneClicked);
			
			float savedYSpeed = rb.velocity.y;
			Vector3 velocityWithGravity = transform.forward * catSpeed;
			velocityWithGravity.y = savedYSpeed;
			rb.velocity = velocityWithGravity;

			Ray catWhisker = new Ray(transform.position, transform.forward);
			RaycastHit rhinfo;

			if(Physics.Raycast(catWhisker, out rhinfo, whiskerLength, ignoreClickTesterLayer)){
				Debug.Log("Jumping on: " + rhinfo.collider.name);
				Ray destRay = new Ray(rhinfo.collider.transform.position + Vector3.up * jumpHeightTester, -Vector3.up);
				RaycastHit rhwaypoint;
				if(Physics.Raycast(destRay, out rhwaypoint, jumpHeightTester, ignoreClickTesterLayer)){
					StartJump(rhwaypoint.point);
				}
			}
		} else {
			rb.velocity = Vector3.zero;
		}



	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			MouseTarget ();
		}
		MoveToTarget ();
	}
}
