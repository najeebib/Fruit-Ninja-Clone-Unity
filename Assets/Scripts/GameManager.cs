using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score elements")]
    private int score;
    private int highScore;
    public Text scoreText;
    public Text bestScoreText;
    [Header("Sounds")]
    public AudioClip sliceSound;
    private AudioSource audioSource;
    [Header("Game over elements")]
    public GameObject gameOverPanel;
    public Text gameOverPanelText;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameOverPanel.SetActive(false);
    }
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        scoreText.text = "Score: 0";
        bestScoreText.text = "Best: " + highScore.ToString();
    }
    public void IncreseScore(int points)
    {
        // increase the score when the user cuts a fruit
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
        // end the game when user hits the bomb
        gameOverPanelText.text = "Your score is: " + score.ToString();
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Bomb hit");
        // display the game over panel
        gameOverPanel.SetActive(true);
    }
    public void ResetartGame()
    {
        // restart the game
        score = 0;
        scoreText.text = "";
        bestScoreText.text = "";
        gameOverPanel.SetActive(false);
        gameOverPanelText.text = "Your score is: " + score.ToString();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(obj);
        }
        Time.timeScale = 1 ;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SliceSound()
    {
        audioSource.PlayOneShot(sliceSound);
    }
}
