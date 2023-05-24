using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    [Header("Finish Panels")]
    [SerializeField] private static GameObject WinWindow;
    [SerializeField] private static GameObject LooseWindow;
    
    public static void FinishLevel(bool isWin)
    {
        if(isWin)
            WinWindow.SetActive(true);
        else
            LooseWindow.SetActive(true);
    }
    
}
