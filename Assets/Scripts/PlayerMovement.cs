using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
     * GroundChecks will allow players jump while sliding on the walls if too far and won't let to jump on the ledges if too close
     * If thrown into air player will start falling immedietelly because of if (!_jumpKeyHeld && _rigidbody.velocity.y > 0). should detect if player was jumping
     * Change CounterJumpForce to CounterJumpForceMultiplier and make the force be based on current jump speed
     */

    public float JumpForce;
    public float MoveSpeed;
    public float MaxFallSpeed;
    public float CounterJumpForceMultiplier;
    public float GroundedCheckDistance = 0.02f;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;

    private Vector2[] _groundChecks = new Vector2[2];
    private bool _grounded = false;
    private bool _jumpKeyHeld = false;
    private bool _playerJumped = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _groundChecks[0] = new Vector2(_collider.bounds.min.x - _collider.edgeRadius, _collider.bounds.min.y - _collider.edgeRadius);
        _groundChecks[1] = new Vector2(_collider.bounds.max.x + _collider.edgeRadius, _collider.bounds.min.y - _collider.edgeRadius);
        foreach (Vector2 groundCheck in _groundChecks)
        {
            _grounded = Physics2D.Raycast(groundCheck, Vector2.down, GroundedCheckDistance, 1 << LayerMask.NameToLayer("Ground"));
            if (_grounded)
            {
                _playerJumped = false;
                break;
            }
        }

        if (InputManager.I.Jumped())
        {
            _jumpKeyHeld = true;
            if (_grounded)
            {
                _rigidbody.AddForce(Vector2.up * JumpForce * _rigidbody.mass, ForceMode2D.Impulse);
                _playerJumped = true;
            }
        }
        else if (InputManager.I.StoppedJumping())
        {
            _jumpKeyHeld = false;
        }
    }

    private void FixedUpdate()
    {
        int horizontal = 0;
        if (InputManager.I.GoingLeft()) horizontal -= 1;
        if (InputManager.I.GoingRight()) horizontal += 1;

        _rigidbody.velocity = new Vector2(horizontal * MoveSpeed, _rigidbody.velocity.y);
        //transform.Translate(horizontal * MoveSpeed * Time.deltaTime, 0f, 0f);

        if (_playerJumped && !_jumpKeyHeld && _rigidbody.velocity.y > 0)
        {
            _rigidbody.AddForce(Vector2.down * _rigidbody.velocity.y * CounterJumpForceMultiplier * _rigidbody.mass);
            _playerJumped = false;
        }

        if (_rigidbody.velocity.y < MaxFallSpeed) _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, MaxFallSpeed);
    }
}
