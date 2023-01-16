using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//этот скрипт отвечает за передвижение GO персонажа в мире

public class Movement : MonoBehaviour // ѕереименовать в Controller
{
    Vector2? fixedVelocity = null;




    public bool useUnscaledTime;
    public Sprite testo;
    Visual visual;
    public float speedModificator; // в отдельный класс с константами надо бл€ть
    private float jumpSpeedModificator; // тоже самое сука
    public float VspeedModificator; // бл€€€€€€€€€€€€€€ть
    public int DashCounter; // стейт машины сука
    Rigidbody2D _rb;
    private float runModificator; // б€лть стейты
    private float layModificator = 1f; // что это бл€ть
    private bool isPressed100Ms; //—” ј
    public bool isRun; //—“≈…“ ћјЎ»Ќџ
    public bool isCrought, isLayed; //ЅЋяяяяяяяя“№

    public bool onGround; // ѕиздец

    
    void Start()
    {
        visual = GetComponent<Visual>();
        _rb = GetComponent<Rigidbody2D>();
        jumpSpeedModificator = 1;
    }

    float oldhspeed = 0;
    
    IEnumerator dash() 
    {
        fixedVelocity = _rb.velocity.normalized * Constants.dashSpeed;
        yield return new WaitForSeconds(Constants.dashTime);
        fixedVelocity = null;
    }


    void forceDash()
    {

    }

    void updateDash()
    {
        if (!Input.GetMouseButtonUp(2))
            return;
        if (DashCounter > 0)
        {

        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        Vector2 controllerOffset = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            _rb.AddForce(Vector2.up, ForceMode2D.Impulse);
        }
        if ((Input.GetKeyUp(KeyCode.CapsLock) || Input.GetMouseButtonUp(2)) /*&& !inDash*/)
        {
            speedModificator *= 2.5f;
            // VspeedModificator *= 2;
            //inDash = true;
            // Camera.main.orthographicSize *= 1.2f;
            StartCoroutine(StopDash());
            //  visual.StartCoroutine("TrailSpawner");
        }
        if (onGround)
            jumpSpeedModificator = 1;
        else
            jumpSpeedModificator = 0.5f;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (isPressed100Ms)
            {
                StopCoroutine(RunCheck());
                StartCoroutine(RunBuff());
                runModificator = 2f;
                isRun = true;
                isPressed100Ms = false;
            }
            else
            {
                isPressed100Ms = true;
                StartCoroutine(RunCheck());
            }
        }
        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) && !isPressed100Ms)
        {
            isRun = false;
            runModificator = 1f;
        }
        /* velocity += new Vector3(Hspeed * speedModificator /* jumpSpeedModificator * layModificator * runModificator * (useUnscaledTime == true ? Time.unscaledTime / 20 : 1), 0, 0);
        _rb.MovePosition(transform.position + velocity);
        if (Hspeed != oldhspeed)
        {
            //  visual.SpeedChanged(Hspeed);
        }
        oldhspeed = Hspeed;
        */
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isCrought == true)
            {
                isLayed = true;
                isCrought = false;
                layModificator = 0.3f;
                visual.ToLay();
            }
            else if (!isLayed)
            {
                isCrought = true;
                layModificator = 0.5f;
                visual.ToCr();
            }
            else
            {
                isLayed = false;
                layModificator = 1f;
            }
        }
    }

    IEnumerator RunCheck()
    {
        yield return new WaitForSeconds(0.3f);
        isPressed100Ms = false;
    }

    IEnumerator RunBuff()
    {
        yield return new WaitForSeconds(0.4f);
        if (isRun && runModificator < 2.9f)
        {
            runModificator += 0.2f;
            StartCoroutine(RunBuff());
        }
    }

    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(0.5f);
        speedModificator /= 2.5f;
        //   VspeedModificator /= 2;
        // Camera.main.orthographicSize /= 1.2f;
        //inDash = false;
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
            {
                onGround = false;
            }
        }
    }

}