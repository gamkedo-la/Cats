using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static int score;
    public Text text;

    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {

        text.text = "" + score;
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
