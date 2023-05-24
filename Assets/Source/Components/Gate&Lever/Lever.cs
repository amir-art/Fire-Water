using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Gate _gate;
    
    [SerializeField] private Sprite _leverEnabled;
    [SerializeField] private Sprite _leverDisabled;

    public bool _isEnabled;
    private SpriteRenderer _spriteRenderer;

    private float timer;

    private void Start()
    {
        timer = 2f;
        _isEnabled = false;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (timer > 0)
            timer -= 1f * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        Player player = other.GetComponent<Player>();
        if (player != null && timer < 0)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.L))
            {
                timer = 2f;
                _isEnabled = !_isEnabled;
                OpenCloseGate(_isEnabled);
            }
        }
        
    }

    private void OpenCloseGate(bool open)
    {
        if (open)
        {
            _gate.OpenGate();
            _spriteRenderer.sprite = _leverEnabled;
        }
        else
        {
            _gate.CloseGate();
            _spriteRenderer.sprite = _leverDisabled;
        }
    }

}
