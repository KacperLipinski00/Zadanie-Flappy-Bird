using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject menuUI, loseUI;
    public PipeSpawner pipeSpawner;
    public PlayerController playerController;
    public int points = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScore;
    public AudioSource GameStartMusic;
    public AudioSource MenuMusic;
    public void StartGame()
    {
        menuUI.SetActive(false);
        pipeSpawner.enabled = true;
        playerController.enabled = true;
        playerController.rb.simulated = true;
        GameStartMusic.Play();
        
    }

    private void ShowLoseUI()
    {
        loseUI.SetActive(true);
        GameStartMusic.Stop();
        MenuMusic.Play();
    }

    public void RepeatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void OnGameOver()
    {
        ShowLoseUI();
        Time.timeScale = 0;
        UpdateHighScore();
    }

    public void UpdateScore()
    {
        points++;
        scoreText.text = points.ToString();
        CheckHighScore();
    }
   void CheckHighScore()
    {
        if(points > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", points);
        }
    }
    void UpdateHighScore()
    {
        HighScore.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
    
}
