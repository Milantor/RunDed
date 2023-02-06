using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private IEnumerator shotRoutine;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Constants.IsMouseDown(0))
        {
            shotRoutine = Shot(0.2f, false);
            StartCoroutine(shotRoutine);
        }

        if (Constants.IsMouseUp(0) && shotRoutine!=null)
        {
            StopCoroutine(shotRoutine);
        }
    }

    private IEnumerator Shot(float shotDelay = 0,bool once = true)
    {
        if (once)
        {
            SummonProjectile();
            StopCoroutine(shotRoutine);
        }
        while (true)
        {
            SummonProjectile();
            yield return new WaitForSeconds(shotDelay);
        }
    }

    private void SummonProjectile()
    {
        Projectile projectile = new(
            gameObject.transform.position,
            (Camera.main.ScreenToWorldPoint(Input.mousePosition) - (transform.position)).normalized,
            Resources.Load<Sprite>("Sprites/bullet"),
            5,
            5
        );
    }
}
