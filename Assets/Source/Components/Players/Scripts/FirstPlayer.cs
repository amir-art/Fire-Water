using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayer : Player
{
    protected override void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _movementX = -1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _movementX = 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            _movementX = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.K)) Jump();

        if (_movementX > 0 && !_facingRight || _movementX < 0 && _facingRight) 
            Flip();
    }
}
