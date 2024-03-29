using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int scoreMultiplier = 10;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private SnakeController snakeController;

    private int highScore;

    private const string HighScoreKey = "HighScore";

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        UpdateScoreText();
    }

    private void Update()
    {
        int currentScore = snakeController.segments.Count * scoreMultiplier;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt(HighScoreKey, highScore);
        }

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + (snakeController.segments.Count * scoreMultiplier).ToString();
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

}
