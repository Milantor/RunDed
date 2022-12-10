using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform SpawnPos;
    private Visual visual;
    private Movement movement;
    [SerializeField] Vector3 normal, cr, lay;
    public int SelectedGun;
    [Header("Pistol")]
    [SerializeField] private Sprite pistolSprite;
    [SerializeField] private int pistolDamage;
    [SerializeField] private float pistolSpeed;
    [Header("Rifle")]
    [SerializeField] private Sprite rifleSprite;
    [SerializeField] private int rifleDamage;
    [SerializeField] private float rifleSpeed;
    [Header("Shotgun")]
    [SerializeField] private Sprite gunSprite;
    [SerializeField] private int gunDamage;
    [SerializeField] private float gunSpeed;
    [SerializeField] private float gunRange;

    private bool rifleJJ;

    void Start()
    {
        visual = FindObjectOfType<Visual>();
        movement = FindObjectOfType<Movement>();
    }

    void Update()
    {
        if (movement.isLayed)
        {
            if (!movement.GetComponent<SpriteRenderer>().flipX)
            {
                SpawnPos.transform.position = transform.position + lay;
            }
            else
            {
                SpawnPos.transform.position = transform.position + new Vector3(-lay.x, lay.y);
            }
        }
        else if (movement.isCrought)
        {
            if (!movement.GetComponent<SpriteRenderer>().flipX)
            {
                SpawnPos.transform.position = transform.position + cr;
            }
            else
            {
                SpawnPos.transform.position = transform.position + new Vector3(-cr.x, cr.y);
            }
        }
        else
        {
            SpawnPos.transform.position = transform.position + normal;
        }
        Vector2 Direction = Input.mousePosition - Camera.main.WorldToScreenPoint(SpawnPos.position);
        float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        SpawnPos.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
        if(Input.mousePosition.x - Camera.main.WorldToScreenPoint(SpawnPos.position).x < 0)
        {
            SpawnPos.GetComponentInChildren<SpriteRenderer>().flipY = true;
        }
        else
        {
            SpawnPos.GetComponentInChildren<SpriteRenderer>().flipY = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
            if (SelectedGun == 2)
            {
                StopAllCoroutines();
                rifleJJ = true;
                StartCoroutine(RifleShot());
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            rifleJJ = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SelectedGun = 0;
            visual.ChangeWeaponSprite(SelectedGun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedGun = 1;
            visual.ChangeWeaponSprite(SelectedGun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedGun = 2;
            visual.ChangeWeaponSprite(SelectedGun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedGun = 3;
            visual.ChangeWeaponSprite(SelectedGun);
        }
    }

    public void Shot()
    {
        switch (SelectedGun)
        {
            case 0:
                //melee
                break;
            case 1:
                //pistol
                SummonProjectile(pistolSprite, pistolDamage, pistolSpeed);
                break;
            case 2:
                //rifle
                SummonProjectile(rifleSprite, rifleDamage, rifleSpeed);
                break;
            case 3:
                //gunshot
                for (int i = 0; i < 10; i++)
                {
                    SummonProjectile(gunSprite, gunDamage, gunSpeed, gunRange);
                }
                break;
        }
    }

    IEnumerator RifleShot()
    {
        while (rifleJJ)
        {
            yield return new WaitForSeconds(0.13f + Random.Range(-0.05f, 0.05f));
            Shot();
        }
        yield return null;
    }

    public void SummonProjectile(Sprite sprite, int damage, float speed, float ranger = 0)
    {
        GameObject _projectile = new GameObject();
        SpriteRenderer _SR = _projectile.AddComponent<SpriteRenderer>();
        Rigidbody2D _rb = _projectile.AddComponent<Rigidbody2D>();
        _projectile.AddComponent<BoxCollider2D>();
        _projectile.AddComponent<SelfDestroyer>();
        _projectile.transform.position = SpawnPos.position;
        Vector3 vector3 = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _projectile.transform.position).normalized;
        Vector2 lookDir = (SelectedGun == 3) ?
            //(Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(Random.Range((1 - ranger), 1 + ranger), Random.Range((1 - ranger), 1 + ranger)).normalized - _projectile.transform.position)
            new Vector3 (vector3.x * (1+Random.Range(1 - ranger, 1 + ranger)), vector3.y * (1+Random.Range(1 - ranger, 1 + ranger)))
            :
            (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _projectile.transform.position);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        _projectile.transform.localEulerAngles = new Vector3(0, 0, angle);
        _projectile.layer = 6;
        _SR.sprite = sprite;
        _rb.gravityScale = 0f;
        //  Vector2 strangeVector = (new Vector2(Random.Range((1 - ranger), 1 + ranger), Random.Range((1 - ranger), 1 + ranger)) + lookDir);
        _rb.AddForce(lookDir.normalized * speed * 25f * Random.Range(0.9f,1.1f), ForceMode2D.Impulse);
    }
}