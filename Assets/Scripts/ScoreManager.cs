using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    [SerializeField] private SnakeController snakeController;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoreText.text = "Score: " + (snakeController.segments.Count * 10f).ToString();
    }

}
