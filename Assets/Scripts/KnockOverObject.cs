using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KnockOverObject : MonoBehaviour {

    public int pointValue;

    public GameObject popUpScore;

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
            DisplayPopUpScore(pointValue);
            ScoreManager.AddPoints(pointValue);

        }

    }

    void DisplayPopUpScore(int points)
    {
        Canvas canvasComponent = GameObject.Find("Canvas").GetComponent<Canvas>();
        GameObject temp = Instantiate(popUpScore) as GameObject;
        temp.transform.SetParent(canvasComponent.gameObject.transform, false);
        temp.GetComponent<Animator>().SetTrigger("hit");

        temp.GetComponent<Text>().text = "+" + points;

    }
}
