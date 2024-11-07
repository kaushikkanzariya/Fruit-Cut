using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool gameOver = false;

    [Header("UI Reference")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI yourScoreText;
    public TextMeshProUGUI highScoreText;

    public int gameScore;

    [SerializeField]
    int HighScore = 0;

    int remainingLives;

    const string HighScoreString = "HighScore";
    const int livesFix = 3;

    void Awake()
    {
        Instance = this;

        HighScore = PlayerPrefs.GetInt(HighScoreString);
    }

    private void Start()
    {
        gameScore = 0;
        remainingLives = livesFix;
        livesText.text = "Lives: " + remainingLives.ToString();

        gameOver = false;
    }

    public void UpdateScore(int Score)
    { 
        gameScore += Score;
        scoreText.text = gameScore.ToString();

        if (gameScore > HighScore)
        {
            PlayerPrefs.SetInt(HighScoreString, gameScore);
        }
    }

    public void UpdateLives()
    {
        if (gameOver == false) 
        {
            remainingLives--;
            livesText.text = "Lives: " + remainingLives.ToString();

            if (remainingLives == 0) 
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.gameObject.SetActive(true);

        yourScoreText.text = "Your Score: " + gameScore.ToString();
        highScoreText.text = "High Score: " + HighScore.ToString();
    }

    public void Click_RestartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
