using UnityEngine;
using System.Collections;

public class TrackCat : MonoBehaviour {
	public GameObject trackObj;
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Slerp(transform.rotation,
			Quaternion.LookRotation(trackObj.transform.position - transform.position), 4.0f * Time.deltaTime);
	}
}
