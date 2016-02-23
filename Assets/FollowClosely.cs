using UnityEngine;
using System.Collections;

public class FollowClosely : MonoBehaviour {

	public Transform follower;

	// Update is called once per frame
	void Update () {
		follower.position = transform.position;	
	}
}
