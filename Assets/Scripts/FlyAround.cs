using UnityEngine;
using System.Collections;

public class FlyAround : MonoBehaviour {
	public float osc1 = 0.0f;
	float oscRate1 = 0.0f;
	public float oscRateRand1 = 1.0f;

	public float osc2 = 0.0f;
	float oscRate2 = 0.0f;
	public float oscRateRand2 = 0.0f;

	float oscRateLimitMinCap = 0.03f;
	float oscRateLimitMaxCap = 0.12f;

	Vector3 lerpStartLoc;
	Vector3 lerpEndLoc;
	float lerpStart;
	float lerpWait;

	public float heightMaxY = 3.0f;
	public float maxAudienceClosenessZ = 2.0f;

	Vector3 corePt;

	// Use this for initialization
	void Start () {
		osc1 = Random.Range(0.0f, 2 * Mathf.PI);
		osc2 = Random.Range(0.0f, 2 * Mathf.PI);
		corePt = transform.position;

		StartCoroutine( ChangeGoal() );
	}

	IEnumerator ChangeGoal() {
		while(true) {
			lerpStartLoc = corePt;
			int safeLoopLimit = 100;
			Vector3 pointAt;
			do {
				pointAt = Random.onUnitSphere;
				if(Physics.Raycast(lerpStartLoc, pointAt*1.4f) == false) {
					break;
				}
			} while(safeLoopLimit-->0);
			lerpEndLoc = corePt + pointAt;
			if(lerpEndLoc.y > heightMaxY) {
				lerpEndLoc.y = heightMaxY;
			}
			if(lerpEndLoc.z < maxAudienceClosenessZ) {
				lerpEndLoc.z = maxAudienceClosenessZ;
			}
			transform.LookAt(lerpEndLoc);
			lerpStart = Time.time;
			lerpWait = Random.Range(1.2f, 2.4f);
			yield return new WaitForSeconds( lerpWait );
		}
	}
	
	// Update is called once per frame
	void Update () {
		oscRate1 += Random.Range(-oscRateRand1, oscRateRand1) * Time.deltaTime;
		oscRate1 = Mathf.Clamp(oscRate1, oscRateLimitMinCap, oscRateLimitMaxCap);
		osc1 += oscRate1;

		oscRate2 += Random.Range(-oscRateRand2, oscRateRand2) * Time.deltaTime;
		oscRate2 = Mathf.Clamp(oscRate2, oscRateLimitMinCap, oscRateLimitMaxCap);
		osc2 += oscRate2;

		transform.Rotate(0.0f, 0.0f, Mathf.Cos(osc2*50.0f)*305.7f*Time.deltaTime);

		corePt = Vector3.Lerp(lerpStartLoc, lerpEndLoc, (Time.time - lerpStart) / lerpWait);
		transform.position = corePt + Mathf.Cos(osc1) * oscRate1 * Vector3.right
			+ Mathf.Cos(osc2) * oscRate2 * Vector3.forward
			+ Mathf.Sin(osc1+osc2) * (oscRate1+oscRate2) * Vector3.up;
	}
}
