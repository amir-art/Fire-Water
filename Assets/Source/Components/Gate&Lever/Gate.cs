using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Sprite _doorClosed;
    [SerializeField] private Sprite _doorOpened;
    
    public bool _isOpen;
    public bool _playerInside;
    
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _isOpen = false;
        _playerInside = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            if(_isOpen)
                _playerInside = true;
            return;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            _playerInside = false;
            return;
        }
    }

    public void OpenGate()
    {
        _isOpen = true;
        _spriteRenderer.sprite = _doorOpened;
    }
    
    public void CloseGate()
    {
        _isOpen = false;
        _spriteRenderer.sprite = _doorClosed;
    }

    public bool Finish()
    {
        if (_isOpen && _playerInside)
            return true;
        return false;
    }
}
