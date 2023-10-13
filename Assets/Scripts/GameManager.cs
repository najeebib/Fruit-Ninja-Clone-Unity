using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public Text bestScoreText;
    private int highScore;
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        scoreText.text = "Score: 0";
        bestScoreText.text = "Best: " + highScore.ToString();
    }
    public void IncreseScore(int points)
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        score += points;
        if(score >  highScore) 
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore",highScore);
        }
        scoreText.text = "Score: " + score.ToString();
        bestScoreText.text = "Best: " + highScore.ToString();
    }
    public void OnBombHit()
    {
        Time.timeScale = 0;
        Debug.Log("Bomb hit");
    }
}
