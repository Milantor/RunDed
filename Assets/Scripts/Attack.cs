using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    ak74,
    glok,
    trail
}

public class Attack : MonoBehaviour
{
    public int HitPoint;
    [SerializeField]
    ProjectileType ProjectileType = ProjectileType.ak74;
    //private GameObject projectile;
    public GameObject weaponPoint;
    public int SPEEEED = 600;
    Visual visual;
    [SerializeField] GameObject weapon;
    float bulletRange, bulletRangeModificator = 1;
    BeutifulCamera BeutifulCamera;
    UITextManager UITextManager;
    UIBarsManager UIBarsManager;
    public int bulletsCount, inGunBulletsCount;
    public bool isReloading;
    public float ReloadTime;
    Movement movement;

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
        movement = GetComponent<Movement>();
        visual = GetComponent<Visual>();
        BeutifulCamera = FindObjectOfType<BeutifulCamera>();
        UITextManager = FindObjectOfType<UITextManager>();
        UIBarsManager = FindObjectOfType<UIBarsManager>();

        ReloadTime = 2.5f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(LongShot(ProjectileType.ak74, SPEEEED));
        }
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && inGunBulletsCount < 30)
        {
            ReloadTime = (30f-inGunBulletsCount)/30f / .25f;
            StartCoroutine(Reload());
            UIBarsManager.UpdateBar("Reload");
        }
        #region Aim
        if (Input.GetMouseButtonDown(1))
        {
            bulletRangeModificator *= 0.5f;
            BeutifulCamera.Aim = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            bulletRangeModificator *= 2f;
            BeutifulCamera.Aim = false;
        }
        #endregion
    }

    IEnumerator LongShot(ProjectileType projectileType, int rateOfFire)
    {
        while (Input.GetMouseButton(0) && inGunBulletsCount > 0)
        {
            --inGunBulletsCount;
            UITextManager.UpdateText("Bullet");
            if (isReloading)
            {
                StopAllCoroutines();
                UIBarsManager.Stop();
                isReloading = false;
                StartCoroutine(LongShot(ProjectileType.ak74, SPEEEED));
            }
            bulletRange = Random.Range(-5, 5);
            #region Projectile spawn
            GameObject _go = new GameObject();
            SpriteRenderer _sr = _go.AddComponent<SpriteRenderer>();
            Rigidbody2D _rb = _go.AddComponent<Rigidbody2D>();
            Projectile _projectile = _go.AddComponent<Projectile>();
            _projectile.ChangeAim(BeutifulCamera.Aim);

            _go.transform.position = weaponPoint.transform.position;
            _sr.sortingLayerName = "SFX";
            _projectile.ded = gameObject;
            _projectile.SetParametres(projectileType);
            _rb.gravityScale = 0;
            _rb.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - weapon.transform.position + new Vector3(0, bulletRange * bulletRangeModificator, 0)).normalized * _projectile.projectileSpeed, ForceMode2D.Impulse);
            _go.transform.right = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - weapon.transform.position).normalized;
            //_go.transform.rotation = Quaternion.Euler(_go.transform.rotation.z, 0, _go.transform.rotation.z);
            #endregion
            yield return new WaitForSeconds(0.1f + Random.Range(-0.05f, 0.05f));
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(ReloadTime);
        if (bulletsCount > 0)
        {
            int minus = 30 - inGunBulletsCount;
            inGunBulletsCount = Mathf.Clamp(inGunBulletsCount + bulletsCount, 0, 30);
            bulletsCount = (bulletsCount - minus > 0) ? bulletsCount - minus : 0;
        }
        UITextManager.UpdateText("Bullet");
        isReloading = false;
    }

    public void Shot(ProjectileType projectileType)
    {
        GameObject _go = new GameObject();
        _go.transform.position = transform.position + new Vector3((movement.Hspeed > 0 ? -3f : 3f), 1.5f, 0);
        SpriteRenderer _sr = _go.AddComponent<SpriteRenderer>();
        _sr.sortingLayerName = "SFX";
        Material material = (Material)Resources.Load("Mat");
        _sr.material = material;
        _sr.color = new Color(1, 1, 1, 0.2f);
        Rigidbody2D _rb = _go.AddComponent<Rigidbody2D>();
        Projectile _projectile = _go.AddComponent<Projectile>();
        _projectile.ded = gameObject;
        _projectile.SetParametres(projectileType);
        _rb.gravityScale = 0;
        _rb.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - weapon.transform.position) * _projectile.projectileSpeed /*(GetComponent<SpriteRenderer>().flipX == false ? 1 : -1), 0*/, ForceMode2D.Impulse);
    }
}