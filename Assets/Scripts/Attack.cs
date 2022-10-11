using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform SpawnPos;

    public int SelectedGun;

    [SerializeField] private Sprite pistolSprite;
    [SerializeField] private int pistolDamage;
    [SerializeField] private float pistolSpeed;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SelectedGun = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedGun = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedGun = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectedGun = 3;
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
                break;
            case 3:
                //gunshot
                break;
        }
    }

    public void SummonProjectile(Sprite sprite, int damage, float speed)
    {
        GameObject _projectile = new GameObject();
        SpriteRenderer _SR = _projectile.AddComponent<SpriteRenderer>();
        Rigidbody2D _rb = _projectile.AddComponent<Rigidbody2D>();
        _projectile.AddComponent<BoxCollider2D>();
        _projectile.transform.position = SpawnPos.position;
        _projectile.layer = 6;
        _SR.sprite = sprite;
        _rb.gravityScale = 0f;

        _rb.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - _projectile.transform.position).normalized * speed, ForceMode2D.Impulse);
    }
}