using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//этот скрипт отвечает за передвижение GO персонажа в мире

public class Movement : MonoBehaviour
{
    public float Hspeed; //скорость(горизонтальная)
    public float Vspeed; //скорость(вертикальная)
    public float speedModificator = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        #region basic move
        Vector3 velocity = Vector3.zero;
        switch (Input.GetAxis("Horizontal")){
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
        velocity += new Vector3(Hspeed * speedModificator, Vspeed * speedModificator, 0);
        transform.position += velocity;
        #endregion
    }
}
