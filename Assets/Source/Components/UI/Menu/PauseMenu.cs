using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuWindow;
    [SerializeField] private Button PauseButton;
    [SerializeField] private Button ResumeButton;
    [SerializeField] private List<Button> MainMenuButton;
    [SerializeField] private List<Button> RestartLevelButton;
    [SerializeField] private Button NextLevelButton;
    
    private void Start()
    {
        foreach (Button item in RestartLevelButton)
        {
            item.onClick.AddListener(delegate{RestartCurrentLevel();});
        }
        foreach (Button item in MainMenuButton)
        {
            item.onClick.AddListener(delegate{BackMainMenu();});
        }
        NextLevelButton.onClick.AddListener(delegate{NextLevel();});
        ResumeButton.onClick.AddListener(delegate{ClosePauseMenu();});
        PauseButton.onClick.AddListener(delegate{OpenPauseMenu();});
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
        if (nextSceneIndex == 0) nextSceneIndex = 1;
        SceneManager.LoadScene (nextSceneIndex);
        Time.timeScale = 1f;
    }
    
    public void RestartCurrentLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
    }

    public void OpenPauseMenu()
    {
        PauseMenuWindow.SetActive(true);
        Time.timeScale = 0f;
    } 
    
    public void ClosePauseMenu()
    {
        PauseMenuWindow.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
