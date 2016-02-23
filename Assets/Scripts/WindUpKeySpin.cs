using UnityEngine;
using System.Collections;

public class WindUpKeySpin : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		transform.Rotate(0.0f, 0.0f,-60.0f * Time.deltaTime);
	}
}
