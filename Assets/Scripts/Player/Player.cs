using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IControllable
{
    public Controller _controller;
    public Combat _combat;
    public Visual _visual;
    public bool onGround = true;
    public int jumpCounter = 1;
    public int dashCounter = 1;
    public PoseState poseState = PoseState.Walk;

    private Vector2? _fixedVelocity; // ???????? ???????? какое-то чмо снесло кодировку не помню что здесь было

    private Rigidbody2D _rb;

    private void Awake()
    {
        _controller = gameObject.AddComponent<Controller>();
        _controller._controllable = this;
        _visual = gameObject.AddComponent<Visual>();
        _visual._player = this;
        _combat = gameObject.AddComponent<Combat>();
        _combat._player = this;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (onGround)
          if (_fixedVelocity is not null)
            _rb.velocity = (Vector2)_fixedVelocity;
    }

    private void Update()
    {
        if (onGround && _fixedVelocity is null)
        {
            jumpCounter = 1; dashCounter = 1;
        }
    }

    public void Dash()
    {
        if (dashCounter <= 0) return;
        dashCounter--; jumpCounter--;
        StartCoroutine(DashCoroutine());
    }
    private IEnumerator DashCoroutine()
    {
        _fixedVelocity = Constants.DASH_SPEED * _rb.velocity.normalized;
        yield return new WaitForSeconds(Constants.DASH_TIME);
        _fixedVelocity = null;
    }

    public void ForceDash(float direction) {}

    public void Jump()
    {
        if (jumpCounter <= 0) return;
        jumpCounter--; onGround = false;
        _rb.AddForce((_rb.velocity.normalized + new Vector2(0, 4)).normalized * Constants.JUMP_POWER);
    }

    public void Move(float value)
    {
        if (Mathf.Abs(value) > 0.01)
        {
            _rb.AddForce(value > 0
                ? new Vector2(Mathf.Clamp(Constants.MAX_WALK_SPEED - _rb.velocityX, 0, Constants.MAX_WALK_ACCELERATION),
                    0)
                : new Vector2(
                    -Mathf.Clamp(Constants.MAX_WALK_SPEED + _rb.velocityX, 0, Constants.MAX_WALK_ACCELERATION),
                    0));
            _rb.drag = 0;
        }
        else
        {
            _rb.drag = 2;
        }
    }

    private List<Collision2D> _collisions = new();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.bounds.min.y <= GetComponent<BoxCollider2D>().bounds.max.y)
        {
            _collisions.Add(collision);
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (_collisions.Contains(collision))
        {
            _collisions.Remove(collision);
            if (_collisions.Count == 0)
                onGround = false;
        }
    }

}

public enum PoseState
{
    Walk, Crouching, Layed
}