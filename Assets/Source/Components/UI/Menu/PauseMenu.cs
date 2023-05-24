using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuWindow;
    [SerializeField] private Button PauseButton;
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button RestartLevelButton;
    //[SerializeField] private Button NextLevelButton;
    
    private void Start()
    {
        //NextLevelButton.onClick.AddListener(delegate{NextLevel();});
        RestartLevelButton.onClick.AddListener(delegate{RestartCurrentLevel();});
        MainMenuButton.onClick.AddListener(delegate{BackMainMenu();});
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
