using UnityEngine;

public class Attack : MonoBehaviour
{
    public int SelectedGun;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

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
    }
}