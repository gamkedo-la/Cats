using UnityEngine;
using System.Collections;

public class KnockOverObject : MonoBehaviour {

    public int pointValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Contact");
            ScoreManager.AddPoints(pointValue);

        }

    }
}
