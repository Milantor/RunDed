using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HitPoint;

    public void GetDamage(int damage)
    {
        HitPoint -= damage;
        if (HitPoint <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
