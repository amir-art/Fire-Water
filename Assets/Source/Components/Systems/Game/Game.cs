using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    
    [Header("Finish Panels")]
    [SerializeField] private  GameObject WinWindow;
    [SerializeField] private  GameObject LooseWindow;

    [Header("Gates")] 
    [SerializeField] private Gate _gate1;
    [SerializeField] private Gate _gate2;

    private void Update()
    {
        if (_gate1.Finish() && _gate2.Finish())
        {
            FinishLevel(true);
            Time.timeScale = 0f;
        }
    }

    public void FinishLevel(bool isWin)
    {
        if(isWin)
            WinWindow.SetActive(true);
        else
            LooseWindow.SetActive(true);
        Time.timeScale = 0f;
    }
    
    
}
