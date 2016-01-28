using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KnockOverObject : MonoBehaviour {

    public int pointValue;

    public GameObject popUpScore;

    private Canvas canvasComponent;

    // Use this for initialization
    void Start () {

        canvasComponent = GameObject.Find("Canvas").GetComponent<Canvas>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other) 
    {
        if (other.collider.tag == "Player" || other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        //if (other.gameObject.layer == LayerMask.NameToLayer("SphereCollider"))
        {
            Debug.Log("Sphere");
            DisplayPopUpScore(pointValue);
            ScoreManager.AddPoints(pointValue);

        }



    }

    void DisplayPopUpScore(int points)
    {

        GameObject temp = Instantiate(popUpScore) as GameObject;
        temp.transform.SetParent(canvasComponent.gameObject.transform, false);
        temp.GetComponent<Animator>().SetTrigger("hit");

        temp.GetComponent<Text>().text = "+" + points;

    }
}
