using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _numberOfJumps;
    
    [SerializeField]private GameObject _firstPlayer;
    [SerializeField]private GameObject _secondPlayer;
    
    private SpriteRenderer _spriteFirstPlayer;
    private SpriteRenderer _spriteSecondPlayer;
    
    private Rigidbody2D _rbFirstPlayer;
    private Rigidbody2D _rbSecondPlayer;
    

    private float _firstMovementX;
    private bool _firstFacingRight = true;
    private int _firstTimesJumped;
    
    private float _secondMovementX;
    private bool _secondFacingRight = true;
    private int _secondTimesJumped;

    void Start()
    {
        _spriteFirstPlayer = _firstPlayer.GetComponent<SpriteRenderer>();
        _spriteSecondPlayer = _secondPlayer.GetComponent<SpriteRenderer>();
        
        _firstMovementX = 0;
        _secondMovementX = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementFirst = new Vector3(_firstMovementX, 0, 0) * (_speed * Time.deltaTime);
        _firstPlayer.transform.Translate(movementFirst);
        
        Vector3 movementSecond = new Vector3(_secondMovementX, 0, 0) * (_speed * Time.deltaTime);
        _secondPlayer.transform.Translate(movementSecond);

        //First Player
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _firstMovementX = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _firstMovementX = 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _firstMovementX = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.C)) Jump(true);

        if (_firstMovementX > 0 && !_firstFacingRight || _firstMovementX < 0 && _firstFacingRight) 
            Flip(true);

        //Second Player
        if (Input.GetKeyDown(KeyCode.A))
        {
            _secondMovementX = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _secondMovementX = 1;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _secondMovementX = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.K)) Jump(false);
        
        if (_secondMovementX > 0 && !_secondFacingRight || _secondMovementX < 0 && _secondFacingRight) 
            Flip(false);
    }
    
    
    private void Flip(bool firstPlayer)
    {
        if (firstPlayer)
        {
            _firstFacingRight = !_firstFacingRight;
            //_spriteFirstPlayer.flipX = !_firstFacingRight;
            Vector3 Scaler = _firstPlayer.transform.localScale;
            Scaler.x *= -1;
            _firstPlayer.transform.localScale = Scaler;
        }
        else 
        {
            _secondFacingRight = !_secondFacingRight;
            //_spriteSecondPlayer.flipX = !_secondFacingRight;
            Vector3 Scaler = _secondPlayer.transform.localScale;
            Scaler.x *= -1;
            _secondPlayer.transform.localScale = Scaler;
        }
    }
    
    private void Jump(bool firstPlayer)
    {
        if (firstPlayer)
        {
            if (_firstTimesJumped < _numberOfJumps)
            {
                _firstTimesJumped += 1;
                _rbFirstPlayer.AddForce(new Vector2(0f, 12f), ForceMode2D.Impulse);
            }
        }
        else 
        {
            if (_secondTimesJumped < _numberOfJumps)
            {
                _secondTimesJumped += 1;
                _rbSecondPlayer.AddForce(new Vector2(0f, 12f), ForceMode2D.Impulse);
            }
        }
    }
}
