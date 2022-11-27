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
            SpawnPos.transform.position = transform.position + lay;
        }
        else if (movement.isCrought)
        {
            SpawnPos.transform.position = transform.position + cr;
        }
        else
        {
            SpawnPos.transform.position = transform.position + normal;
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
            yield return new WaitForSeconds(0.1f);
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
        Vector2 lookDir = (SelectedGun == 3) ?
            (Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(Random.Range((1 - ranger), 1 + ranger), Random.Range((1 - ranger), 1 + ranger)) - _projectile.transform.position)
            :
            (Camera.main.ScreenToWorldPoint(Input.mousePosition) - _projectile.transform.position);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        _projectile.transform.localEulerAngles = new Vector3(0, 0, angle);
        _projectile.layer = 6;
        _SR.sprite = sprite;
        _rb.gravityScale = 0f;
        //  Vector2 strangeVector = (new Vector2(Random.Range((1 - ranger), 1 + ranger), Random.Range((1 - ranger), 1 + ranger)) + lookDir);
        _rb.AddForce(lookDir / lookDir.magnitude * speed * 25f, ForceMode2D.Impulse);
    }
}