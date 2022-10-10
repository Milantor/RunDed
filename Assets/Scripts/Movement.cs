using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//этот скрипт отвечает за передвижение GO персонажа в мире

public class Movement : MonoBehaviour
{
    public bool useUnscaledTime;
    public Sprite testo;
    Visual visual;
    public float Hspeed; //скорость(горизонтальная)
    public float Vspeed; //скорость(вертикальная)
    public float speedModificator;
    private float jumpSpeedModificator;
    public float VspeedModificator;
    public bool inDash;
    Rigidbody2D _rb;

    public bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        visual = GetComponent<Visual>();
        _rb = GetComponent<Rigidbody2D>();
        jumpSpeedModificator = 1;
    }

    float oldhspeed = 0;
    // Update is called once per frame
    void Update()
    {
        #region basic move
        Vector3 velocity = Vector3.zero;
        #region Horizontal
        //switch (Input.GetAxis("Horizontal"))
        //{
        //    case > 0:
        //        Hspeed = 1;
        //        break;
        //    case < 0:
        //        Hspeed = -1;
        //        break;
        //    case 0:
        //        Hspeed = 0;
        //        break;
        //}
        Hspeed = Input.GetAxis("Horizontal");
        #endregion
        #region Vertical
        #region Up
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            _rb.AddForce(Vector2.up * Vspeed, ForceMode2D.Impulse);
            //StartCoroutine(Jump());
            //Debug.Log("JUMP!");
        }
        if (_rb.velocity.y > 0)
        {
            _rb.gravityScale = 3;
        }
        else if(_rb.velocity.y == 0)
        {
            _rb.gravityScale = 1;
        }
        else 
        {
            _rb.gravityScale = 5;
        }
        #endregion
        #region Down
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    if (!onGround)
        //    {
        //        StartCoroutine(Down());
        //    }
        //}
        #endregion
        #endregion
        #region Dash
        if ((Input.GetKeyUp(KeyCode.CapsLock) || Input.GetMouseButtonUp(2)) && !inDash)
        {
            speedModificator *= 2.5f;
           // VspeedModificator *= 2;
            inDash = true;
           // Camera.main.orthographicSize *= 1.2f;
            StartCoroutine(StopDash()); 
            visual.StartCoroutine("TrailSpawner");
        }
        #endregion
        #region MOOOVE
        if (onGround)
            jumpSpeedModificator = 1;
        else
            jumpSpeedModificator = 0.5f;
        velocity += new Vector3(Hspeed * speedModificator * jumpSpeedModificator * (useUnscaledTime == true ? Time.unscaledTime/20 : 1), 0, 0);
        _rb.MovePosition(transform.position + velocity);
        if (Hspeed != oldhspeed)
        {
            visual.SpeedChanged(Hspeed);
        }
        oldhspeed = Hspeed;
        #endregion
        #endregion
    }
    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(0.5f);
        speedModificator /= 2.5f;
     //   VspeedModificator /= 2;
       // Camera.main.orthographicSize /= 1.2f;
        inDash = false;
    }

    //IEnumerator Jump()
    //{
    //    while(Vspeed < 1)
    //    {
    //        Vspeed = Mathf.Lerp(Vspeed, 15, 0.5f + Time.deltaTime);
    //        yield return new WaitForSeconds(0.05f);
    //    }
    //    yield return new WaitForSeconds(1 / 4);
    //    while(!onGround || Vspeed > 1.5f )
    //    {
    //        Vspeed = Mathf.Lerp(Vspeed, 0, 0.05f + Time.deltaTime);
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //    Vspeed = 0;
    //}

    //IEnumerator Down()
    //{
    //    while (Input.GetKey(KeyCode.S) && (!onGround || Vspeed > -4))
    //    {
    //        Vspeed = Mathf.Lerp(Vspeed, -10, 0.2f + Time.deltaTime);
    //        yield return new WaitForSeconds(0.05f);
    //    }
    //    Vspeed = 0;
    //}

    List<Collision2D> collisions = new List<Collision2D>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.bounds.min.y <= GetComponent<BoxCollider2D>().bounds.max.y)
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
            {
                onGround = false;
            }
        }
    }

}