using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ProjectileCalibre
{
    m545
}

public enum PtojectileSpecial
{
    Normal = 0
}

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public float projectileLifeTime;
    public float projectileDamage;
    public GameObject ded;
    public bool isAim;

    public void ChangeAim(bool Aim)
    {
        isAim = Aim;
    }

    public void SetParametres(ProjectileType projectileType)
    {
        switch (projectileType)
        {
            case ProjectileType.ak74:
                projectileSpeed = 910;
                projectileLifeTime = 1;
                projectileDamage = 1 * ((isAim == true) ? 1.3f : 1);
                Sprite[] ss = Resources.LoadAll<Sprite>("Sprites/ForSamos12111");
                GetComponent<SpriteRenderer>().sprite = ss.Single(s => s.name == "bul" /*"AK-74-P"*/);
                //GetComponent<SpriteRenderer>().material = ded.GetComponent<Visual>().m;
                StartCoroutine(KillProjectile(gameObject));
                break;
            case ProjectileType.trail:
                projectileSpeed = 0;
                projectileLifeTime = 0.1f;
                projectileDamage = 0;
                Sprite[] sss = Resources.LoadAll<Sprite>("Sprites/allSam1");
                GetComponent<SpriteRenderer>().sprite = sss.Single(s => s.name == "YO"/*((ded.GetComponent<SpriteRenderer>().sprite.name == "Basic_Ded") ? "10" : ded.GetComponent<SpriteRenderer>().sprite.name + "0")*/);
                StartCoroutine(KillProjectile(gameObject));
                break;
            case ProjectileType.glok:
                break;

        }
    }

    IEnumerator KillProjectile(GameObject projectile)
    {
        yield return new WaitForSeconds(projectileLifeTime);
        if (projectile != null)
            Destroy(projectile);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        collision.gameObject.GetComponent<Enemy>().GetDamage(Damage);
    //    }
    //    Destroy(gameObject);
    //}
}