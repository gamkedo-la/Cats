using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {

    public int delay;

	
	// Update is called once per frame
	void Update () {

        Destroy(gameObject, delay);

	}
}
