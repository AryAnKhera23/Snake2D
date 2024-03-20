using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button PlayButton;
    [SerializeField] Button MenuButton;
    public void Awake()
    {
        PlayButton.onClick.AddListener(LoadMainScene);
        MenuButton.onClick.AddListener(Quit);
    }

    private void LoadMainScene()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void Quit()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }
}
