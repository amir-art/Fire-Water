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

    [Header("Players")] 
    [SerializeField] private GameObject _player1;
    [SerializeField] private GameObject _player2;
    
    [Header("SpawnPoints")] 
    [SerializeField] private Transform _player1Spawn;
    [SerializeField] private Transform _player2Spawn;
    
    [Header("Gates")] 
    [SerializeField] private Gate _gate1;
    [SerializeField] private Gate _gate2;

    private void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(StartLevel());
    }
    private void Update()
    {
        if (_gate1.Finish() && _gate2.Finish())
        {
            FinishLevel(true);
            Time.timeScale = 0f;
        }
    }
    
    private IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(1f);
        Player player1 = Instantiate(_player1, _player1Spawn.position, Quaternion.identity).GetComponent<Player>();
        player1.SetGameSystem(this);
        Player player2 = Instantiate(_player2, _player2Spawn.position, Quaternion.identity).GetComponent<Player>();
        player2.SetGameSystem(this);
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
