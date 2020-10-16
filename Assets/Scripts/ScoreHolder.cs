using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreHolder : MonoBehaviour 
{
    public int score = 0;
    public Text scoreText;
    public Text finalScoreText;
    public Text bestScoreText;

    private void Update()
    {
        ShowScore();
    }

    public void AddToScore(int amount) => score += amount;

    public int GetScore() => score;

    public void ShowScore() => scoreText.text = score.ToString();

    public void GameOver()
    {
        finalScoreText.text = score.ToString();
        int bestScore = PlayerPrefs.GetInt("BestScoreDisplay", 0);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScoreDisplay", score);
        }
        bestScoreText.text = PlayerPrefs.GetInt("BestScoreDisplay", 0).ToString();
    }
}