using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button StartLevelButton;
    [SerializeField] private Button ExitButton;
    
    private void Start()
    {
        StartLevelButton.onClick.AddListener(delegate{StartFirstLevel();});
        ExitButton.onClick.AddListener(delegate{QuitGame();});
    }

    public void StartFirstLevel()
    {
        SceneManager.LoadScene (1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
