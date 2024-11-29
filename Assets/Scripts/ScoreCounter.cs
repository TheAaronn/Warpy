using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start() {
        UpdateScoreText();
    }

    void UpdateScoreText() {
        if (score < 0){
            score = 0;
            scoreText.text = string.Format("SCORE: {0}", score);
        }else {
            scoreText.text = string.Format("SCORE: {0}", score);
        }
    }

    public void GainScore() {
        score+=10;
        UpdateScoreText();
    }
    public void LoseScore() {
        score-=50;
        UpdateScoreText();
    }
}
