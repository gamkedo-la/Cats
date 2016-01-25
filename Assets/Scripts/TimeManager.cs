using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public float startingTime;

    private Text displayTimer;
    private float currentTime;
    private bool paused;

    // Use this for initialization
    void Start () {

        displayTimer = GetComponent<Text>();
        currentTime = startingTime;
        displayTimer.text = currentTime.ToString();
            
	}
	
	// Update is called once per frame
	void Update () {

        if (!paused && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            displayTimer.text = Mathf.Round(currentTime).ToString();
        }

    }

    public void ResetTimer()
    {
        currentTime = startingTime;
    }

    public void StartTimer()
    {
        paused = false;
    }

    public void StopTimer()
    {
        paused = true;
    }

    public bool CheckIfTimeIsUp()
    {
        if (currentTime <= 0)
            return true;
        else
            return false;
    }
}
