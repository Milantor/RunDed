using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    fatDed,
    trail
}

public class Attack : MonoBehaviour
{
    public int HitPoint;
    [SerializeField]
    ProjectileType ProjectileType = ProjectileType.fatDed;
    //private GameObject projectile;
    //private GameObject weapon;

    private void Start()
    {
        //GameObject _go = new GameObject();
        //_go.transform.position = gameObject.transform.position;
        //_go.AddComponent<SpriteRenderer>();
        //Projectile _projectile =  _go.AddComponent<Projectile>();
        //_projectile.SetParametres(ProjectileType);
        //weapon = transform.GetChild(0).gameObject;
        //playerControl = GetComponent<PlayerControl>();
        //if (projectileSpeed == 0)
        //    projectileSpeed = 15;
        //if (projectileLifeTime == 0)
        //    projectileLifeTime = 1;
        //if (projectileDamage == 0)
        //    projectileDamage = 1;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot(ProjectileType);
        }
    }

    public void Shot(ProjectileType projectileType)
    {
        GameObject _go = new GameObject();
        _go.transform.position = gameObject.transform.position;
        SpriteRenderer _sr = _go.AddComponent<SpriteRenderer>();
        _sr.sortingLayerName = "SFX";
        Rigidbody2D _rb = _go.AddComponent<Rigidbody2D>();
        Projectile _projectile = _go.AddComponent<Projectile>();
        _projectile.ded = gameObject;
        _projectile.SetParametres(projectileType);
        _rb.gravityScale = 0;
        _rb.AddForce(new Vector2(_projectile.projectileSpeed * (GetComponent<SpriteRenderer>().flipX == false ? 1 : -1), 0), ForceMode2D.Impulse);
        //    GameObject _projectile = Instantiate(projectile);
        //    _projectile.transform.position = weapon.transform.position;
        //    _projectile.GetComponent<Projectile>().Damage = projectileDamage;
        //    if (playerControl.isRight)
        //        _projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(projectileSpeed, 0), ForceMode2D.Impulse);
        //    if (!playerControl.isRight)
        //        _projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(-projectileSpeed, 0), ForceMode2D.Impulse);
        //    StartCoroutine("KillProjectile", _projectile);
    }
}
