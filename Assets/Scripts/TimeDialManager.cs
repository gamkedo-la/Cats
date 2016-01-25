using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeDialManager : MonoBehaviour {

    public float startingTime;
    
    private Image radialImage;
    private float currentTime;
    private bool paused;

    // Use this for initialization
    void Start () {

        paused = false;
        radialImage = GetComponent<Image>();
        currentTime = startingTime;
            
	}
	
	// Update is called once per frame
	void Update () {

        if (!paused && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            radialImage.fillAmount = currentTime / startingTime;

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
