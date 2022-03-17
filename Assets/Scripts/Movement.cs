using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//этот скрипт отвечает за передвижение GO персонажа в мире

public class Movement : MonoBehaviour
{
    public Sprite testo;
    Visual visual;
    public float Hspeed; //скорость(горизонтальная)
    public float Vspeed; //скорость(вертикальная)
    public float speedModificator;

    public bool inDash;

    // Start is called before the first frame update
    void Start()
    {
        visual = GetComponent<Visual>();
    }

    float oldhspeed = 0;
    // Update is called once per frame
    void Update()
    {
        #region basic move
        Vector3 velocity = Vector3.zero;
        #region Horizontal
        switch (Input.GetAxis("Horizontal"))
        {
            case > 0:
                Hspeed = 1;
                break;
            case < 0:
                Hspeed = -1;
                break;
            case 0:
                Hspeed = 0;
                break;
        }
        #endregion
        #region Dash
        if (Input.GetKeyUp(KeyCode.CapsLock) && !inDash)
        {
            speedModificator *= 20;
            inDash = true;
            Camera.main.orthographicSize *= 1.2f;
            StartCoroutine(StopDash());
            visual.StartCoroutine("TrailSpawner");
        }
        #endregion
        velocity += new Vector3(Hspeed * speedModificator, Vspeed * speedModificator, 0);
        transform.position += velocity;
        if (Hspeed != oldhspeed)
        {
            visual.SpeedChanged(Hspeed);
        }
        oldhspeed = Hspeed;
        #endregion
    }
    IEnumerator StopDash()
    {
        yield return new WaitForSeconds(1f);
        speedModificator /= 20;
        Camera.main.orthographicSize /= 1.2f;
        inDash = false;
    }
}
