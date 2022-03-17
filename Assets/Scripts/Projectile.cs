using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public float projectileLifeTime;
    public int projectileDamage;
    public GameObject ded;

    public void SetParametres(ProjectileType projectileType)
    {
        switch (projectileType)
        {
            case ProjectileType.fatDed:
                projectileSpeed = 700;
                projectileLifeTime = 1;
                projectileDamage = 1;
                GetComponent<SpriteRenderer>().sprite = /*FindObjectOfType<Movement>().testo;*/Resources.Load("Sprites/gay", typeof(Sprite)) as Sprite;
                StartCoroutine(KillProjectile(gameObject));
                break;
            case ProjectileType.trail:
                projectileSpeed = 0;
                projectileLifeTime = 0.1f;
                projectileDamage = 0;
                Sprite[] sss = Resources.LoadAll<Sprite>("Sprites/allSam1");
                GetComponent<SpriteRenderer>().sprite = sss.Single(s => s.name == (ded.GetComponent<SpriteRenderer>().sprite.name) + "0");
                StartCoroutine(KillProjectile(gameObject));
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