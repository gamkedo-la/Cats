using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static int score;
    public Text text;
    private AudioSource rollingScoreSound;

    //the rolling score displayed on screen
    public int rollingScore;

    //the amount of points to add at a time to the rolling score
    public int rollingScoreInterval = 10;

    void Start()
    {
        text = GetComponent<Text>();
        rollingScoreSound = GetComponent<AudioSource>();
        score = 0;
        rollingScore = 0;
    }

    void Update()
    {
        
        if(rollingScore < score)
        {
            rollingScore += rollingScoreInterval;
//            rollingScoreSound.Play();

        }else if(rollingScore >= score)
        {
            rollingScore = score;
        }
        else
        {
            rollingScore = 0;
        }

        text.text = "" + rollingScore;
    }

    public static void AddPoints(int numberOfPoints)
    {
        score += numberOfPoints;
    }

    public static void Reset()
    {
        score = 0;
    }
}
