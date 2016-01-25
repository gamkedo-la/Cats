using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Gravity : MonoBehaviour {

    public int pointValue;

    public GameObject popUpScore;

    private Canvas canvasComponent;

    Rigidbody rb;
	Collider myCol;
	void Start(){

		rb = GetComponent<Rigidbody>();
		myCol = GetComponent<Collider> ();

        canvasComponent = GameObject.Find("Canvas").GetComponent<Canvas>();

    }

	public void EnableGravity(){
		rb.useGravity = true;
		myCol.isTrigger = false;
        ScoreManager.AddPoints(pointValue);
        DisplayPopUpScore(pointValue);
	}

    void DisplayPopUpScore(int points)
    {

        GameObject temp = Instantiate(popUpScore) as GameObject;
        temp.transform.SetParent(canvasComponent.gameObject.transform, false);
        temp.GetComponent<Animator>().SetTrigger("hit");

        temp.GetComponent<Text>().text = "+" + points;

    }
}
