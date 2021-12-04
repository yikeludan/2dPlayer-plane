using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    static Text scoreText;


    private void Awake()
    {
        scoreText = this.GetComponent<Text>();
    }

    private void Start()
    {
        ScoreManager.Instance.ResetScore();
    }

    public static void upScore(int score)
    {
        if (score == 0)
        {
            scoreText.text = "0";
        }
        else
        {
            string orScore = scoreText.text;
            print("orScore = "+orScore);
            float tempScore = float.Parse(orScore);
            int resScore = (int) tempScore;
            resScore += score;
            scoreText.text = resScore.ToString();
        }

      
    }

    public static void upScale(Vector3 scale)
    {
        scoreText.rectTransform.localScale = scale;
    }

}
