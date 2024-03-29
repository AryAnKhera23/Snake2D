using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button QuitButton;
    [SerializeField] private Button SinglePlayerButton;
    [SerializeField] private Button TwoPlayerButton;
    [SerializeField] private GameObject SelectModeObject;
    
    public void Awake()
    {
       AddButtonListeners();
    }

    private void AddButtonListeners()
    {
        PlayButton.onClick.AddListener(SelectMode);
        QuitButton.onClick.AddListener(Quit);
        SinglePlayerButton.onClick.AddListener(LoadSinglePlayerScene);
        TwoPlayerButton.onClick.AddListener(LoadTwoPlayerScene);
    }

    
    private void LoadTwoPlayerScene()
    {
        if (SoundManager.Instance != null)
            SoundManager.Instance.Play(Sounds.ButtonClick);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 2);
    }

    private void LoadSinglePlayerScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void SelectMode()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SelectModeObject.SetActive(true);
    }

    private void Quit()
    {
        if (SoundManager.Instance != null)
            SoundManager.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }
}
