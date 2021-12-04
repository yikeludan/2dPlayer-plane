using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : PersisterSingletion<ScoreManager>
{
    private int score;
    private int currentScore;

    public void ResetScore()
    {
        score = 0;
        currentScore = 0;
        ScoreDisplay.upScore(score);
    }

    public void addScore(int score)
    {
        currentScore += score;
        StartCoroutine(nameof(addScoreCor));
    }

    IEnumerator addScoreCor()
    {
        ScoreDisplay.upScale(new Vector3(1.5f,1.5f,1.5f));
        while (score<currentScore)
        {
            score += 1;
            ScoreDisplay.upScore(score);
            yield return null;
        }
        ScoreDisplay.upScale(Vector3.one);
    }
}
