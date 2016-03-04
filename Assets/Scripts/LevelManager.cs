using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public string nextLevelToLoad;

    private TimeDialManager timer;
    private Canvas canvasComponent;
    private CatController cat;

    // Use this for initialization
    void Start () {

        timer = FindObjectOfType<TimeDialManager>();

        canvasComponent = GameObject.Find("Canvas Level End").GetComponent<Canvas>();
		canvasComponent.gameObject.SetActive(false);

        cat = FindObjectOfType<CatController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (timer.CheckIfTimeIsUp())
        {
            EndLevel();
        }
	}

    public void LoadNextLevel()
    {
        Application.LoadLevel(nextLevelToLoad);
    }

    private void EndLevel()
    {
        cat.enabled = false;
		canvasComponent.gameObject.SetActive(true);
    }
}
