using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static int _stringSpeedId = Animator.StringToHash("speed");
    private static int _stringJumpId = Animator.StringToHash("jump");
    private static int _stringDeathId = Animator.StringToHash("death");
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    public bool _isWaterProtected;
    
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _checkRadius;
    [SerializeField] private LayerMask _groundLayer;
    
    [SerializeField] private Game _game;

    private Rigidbody2D _rbPlayer;
    private Animator _animator;

    protected float _movementX;
    protected bool _facingRight = true;
    
    private bool death;

    protected void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rbPlayer = gameObject.GetComponent<Rigidbody2D>();
        _movementX = 0;
    }

    protected void Update()
    {
        Vector2 movement = new Vector2(_movementX, 0) * (_speed * Time.deltaTime);
        Vector2 velocity = _rbPlayer.velocity;
        velocity.x = movement.x * _speed;
        _rbPlayer.velocity = velocity;
        
        Move();
        _animator.SetFloat(_stringSpeedId, Mathf.Abs(_movementX));
        _animator.SetFloat(_stringJumpId, velocity.y);
    }

    protected virtual void Move(){}
    
    
    protected void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
    protected void Jump()
    {
        if (IsGrounded())
        {
            Vector2 velocity = _rbPlayer.velocity;
            velocity.y = _jumpForce;

            _rbPlayer.velocity = velocity;
        }
        
    }

    public void OnDeath()
    {
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        _animator.SetBool(_stringDeathId,true);
        // _damageSound.Play();
        yield return new WaitForSeconds(1f);
        // _damageSound.Stop();
        Destroy(gameObject);
        _game.FinishLevel(false);
    }
    
    protected bool IsGrounded() => Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _groundLayer);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(_groundCheck.position, _checkRadius);

        Gizmos.color = Color.white;
    }

    public void SetGameSystem(Game game)
    {
        _game = game;
    }
}
