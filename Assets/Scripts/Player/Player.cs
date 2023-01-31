using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Player : MonoBehaviour, IControllable
{
    public bool onGround = true;
    public int jumpCounter = 1;
    public int dashCounter = 1;
    public PoseState poseState = PoseState.Walk;

    private Vector2? _fixedVelocity = null; // �������� ��������

    private Rigidbody2D _rb;

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
        StartCoroutine(dash());
    }
    IEnumerator dash()
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
        if (value > 0)
            _rb.AddForce(new Vector2(Mathf.Clamp(Constants.MAX_WALK_SPEED - _rb.velocityX, 0, Constants.MAX_WALK_ACCELERATION), 0));
        else
            _rb.AddForce(new Vector2(-Mathf.Clamp(Constants.MAX_WALK_SPEED + _rb.velocityX, 0, Constants.MAX_WALK_ACCELERATION), 0));
    }

    List<Collision2D> collisions = new List<Collision2D>();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.bounds.min.y <= GetComponent<BoxCollider2D>().bounds.max.y)
        {
            collisions.Add(collision);
            onGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collisions.Contains(collision))
        {
            collisions.Remove(collision);
            if (collisions.Count == 0)
                onGround = false;
        }
    }

}

public enum PoseState
{
    Walk, Crouching, Layed
}