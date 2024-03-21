using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Button playAgainButton;
    [SerializeField] Button returnToMenuButton;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] GameObject snake;
    [SerializeField] GameObject consumables;
    [SerializeField] GameObject player1Win;
    [SerializeField] GameObject player2Win;
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
        SoundManager.Instance.Play(Sounds.ButtonClick);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ReturnToMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
