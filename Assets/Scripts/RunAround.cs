using UnityEngine;
using System.Collections;

public class RunAround : MonoBehaviour {
	public float maxAudienceClosenessZ = 2.0f;
	Vector3 lerpStartLoc;
	Vector3 lerpEndLoc;
	float lerpStart;
	float lerpWait;
	bool isGoing = false;
	public Transform ratRunArea;

	// Use this for initialization
	void Start () {
		StartCoroutine( ChangeGoal() );
	}

	IEnumerator ChangeGoal() {
		yield return new WaitForSeconds( 0.1f ); // for scene room loaded additively to reposition via parent
		isGoing = true;
		while(true) {
			lerpStartLoc = transform.position;
			int safeLoopLimit = 100;
			Vector3 pointAt;
			pointAt.y = 0.0f;
			float left = ratRunArea.position.x - ratRunArea.localScale.x*0.5f;
			float right = ratRunArea.position.x + ratRunArea.localScale.x*0.5f;
			float front = ratRunArea.position.z - ratRunArea.localScale.z*0.5f;
			float back = ratRunArea.position.z + ratRunArea.localScale.z*0.5f;
			do {
				Vector2 circ = Random.insideUnitCircle * 4.0f;
				pointAt.x = circ.x;
				pointAt.z = circ.y;
				lerpEndLoc = transform.position + pointAt;
				if(lerpEndLoc.x > left && lerpEndLoc.x < right && 
					lerpEndLoc.z > front && lerpEndLoc.z < back ) {
					break;
				}
			} while(safeLoopLimit-->0);
			if(lerpEndLoc.z < maxAudienceClosenessZ) {
				lerpEndLoc.z = maxAudienceClosenessZ;
			}
			lerpStart = Time.time;
			lerpWait = Random.Range(0.9f, 1.2f);
			yield return new WaitForSeconds( lerpWait );
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(isGoing) {
			transform.rotation = Quaternion.Slerp(transform.rotation,
				Quaternion.LookRotation(lerpEndLoc-lerpStartLoc),Time.deltaTime * 7.0f);
			transform.position = Vector3.Lerp(lerpStartLoc, lerpEndLoc, (Time.time - lerpStart) / lerpWait);
		}
	}
}
