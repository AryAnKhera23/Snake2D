using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button returnToMenuButton;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private GameObject snake;
    [SerializeField] private GameObject consumables;
    [SerializeField] private GameObject player1Win;
    [SerializeField] private GameObject player2Win;
    public void Awake()
    {
        playAgainButton.onClick.AddListener(ReloadScene);
        returnToMenuButton.onClick.AddListener(ReturnToMenu);
    }

    public void PlayerDead(int player)
    {
        if(player1Win != null && player2Win != null)
        {
            if (player == 1)
            {
                player2Win.SetActive(true);
            }
            else if (player == 2)
            {
                player1Win.SetActive(true);
            }
        }
        gameObject.SetActive(true);
        snake.SetActive(false);
        Destroy(consumables);
    }
    private void ReloadScene()
    {
        if(SoundManager.Instance != null)
        {
            SoundManager.Instance.Play(Sounds.ButtonClick);
        }
        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ReturnToMenu()
    {
        if (SoundManager.Instance != null)
            SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
