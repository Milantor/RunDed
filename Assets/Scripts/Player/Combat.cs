using System.Collections;
using UnityEngine;

public class Combat : MonoBehaviour
{
    private IEnumerator shotRoutine;
    [SerializeField] private GameObject rifleProjectile; //#TODO: DELETE
    public int maxBulletCount, bulletCount; //#TODO: DELETE

    private void Start()
    {
        Pool.New("rifleProjectile", rifleProjectile);
        maxBulletCount = 60;
        bulletCount = maxBulletCount;
        Debug.Log("Say gex");
    }

    private void Update()
    {
        if (Constants.IsMouseDown(0))
        {
            shotRoutine = Shot(0.15f, false);
            StartCoroutine(shotRoutine);
        }
        if (Constants.IsMouseUp(0) && shotRoutine!=null)
        {
            StopCoroutine(shotRoutine);
        }

        if (Constants.IsKeyDown("Reload"))
        {
            StartCoroutine(nameof(Reload));
        }
    }

    private IEnumerator Shot(float shotDelay = 0,bool once = true)
    {
        if (bulletCount <= 0)
        {
            StopCoroutine(shotRoutine);
        }
        if (once)
        {
            SummonProjectile();
            bulletCount--;
            StopCoroutine(shotRoutine);
        }
        while (bulletCount > 0)
        {
            SummonProjectile();
            bulletCount--;
            yield return new WaitForSeconds(shotDelay);
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(Constants.RELOAD_TIME);
        bulletCount = maxBulletCount;
    }
    
    private void SummonProjectile()
    { 
        var go = Pool.pools["rifleProjectile"].Get();
        go.GetComponent<Projectile>().Launch();
    }
}
