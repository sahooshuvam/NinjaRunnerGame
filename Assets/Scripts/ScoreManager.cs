using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoretext;


    public void ScoreCalculator(int scoreValue)
    {
        score = score + scoreValue;
        scoretext.text = score.ToString();
        print("Score: " +score);
    }
}
