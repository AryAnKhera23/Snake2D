using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] Button playAgainButton;
    [SerializeField] Button returnToMenuButton;
    [SerializeField] SnakeController snakeController;
    public void Awake()
    {
        

        playAgainButton.onClick.AddListener(ReloadScene);
        returnToMenuButton.onClick.AddListener(ReturnToMenu);
    }

    public void PlayerDead()
    {
        gameObject.SetActive(true);
        snakeController.enabled = false;
    }
    private void ReloadScene()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Debug.Log("Reload Scene button clicked.");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ReturnToMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Debug.Log("Return To Menu button clicked.");
        SceneManager.LoadScene(0);
    }
}
