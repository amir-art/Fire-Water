using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayer : Player
{
    protected override void Move()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _movementX = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _movementX = 1;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _movementX = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.C)) Jump();

        if (_movementX > 0 && !_facingRight || _movementX < 0 && _facingRight) 
            Flip();
    }
}
