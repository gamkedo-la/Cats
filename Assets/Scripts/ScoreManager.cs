using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance;
	public int winningScore = 1000;
    public static int score;
	public TimeDialManager timerToAddBackTo;
    public Text text;
    private AudioSource rollingScoreSound;
	private SoundStatementSet soundStatementSet;

    //the rolling score displayed on screen
    public int rollingScore;

    //the amount of points to add at a time to the rolling score
    public int rollingScoreInterval = 10;

    void Start()
    {
		instance = this;

        text = GetComponent<Text>();
        rollingScoreSound = GetComponent<AudioSource>();
		soundStatementSet = GetComponent<SoundStatementSet>();

        score = 0;
        rollingScore = 0;
    }

	public void CheckFinalScore(){
		if (score > winningScore) {
			if (instance.soundStatementSet) {
				instance.soundStatementSet.RandomStatement ();
			} 
		}else {
			timerToAddBackTo.FailedGame ();
		}
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
		if(instance.soundStatementSet) {
			instance.soundStatementSet.RandomStatement();
		}
//		if(instance.timerToAddBackTo) {
//			instance.timerToAddBackTo.ResetTimer();
//		}

        score += numberOfPoints;
    }

    public static void Reset()
    {
        score = 0;
    }
}
