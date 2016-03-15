using UnityEngine;
using System.Collections;

public class WayPointData : MonoBehaviour {


	// Will revisit later
	void OnTriggerEnter (Collider other) {

		CatController cat = other.gameObject.GetComponent<CatController> ();

		if (cat != null) {
			cat.moving = false;
		}
	}
}