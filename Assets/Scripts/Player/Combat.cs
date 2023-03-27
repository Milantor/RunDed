using System.Collections;
using UnityEngine;

/// <summary>
/// Боевая система
/// </summary>
public class Combat : MonoBehaviour
{
    private IEnumerator shotRoutine;
    [SerializeField] private GameObject rifleProjectile; //#TODO: DELETE
    public int maxBulletCount, bulletCount; //#TODO: DELETE
    private Weapon weapon;
    public Player _player;
    private Visual _visual;

    private void Start()
    {
        _visual = _player._visual;
        Pool.New("rifleProjectile", rifleProjectile);
        maxBulletCount = weapon.magazineSize;
        bulletCount = maxBulletCount;
        Debug.Log("Say gex");
    }

    public void ChangeWeapon(Weapon _weapon)
    {
        weapon = _weapon;
        _visual.ChangeWeaponSprite(weapon);
        bulletCount = 0;
        maxBulletCount = weapon.magazineSize;
    }

    private void Update()
    {
        if (Constants.IsMouseDown(0))
        {
            shotRoutine = weapon.bulletsPerShot == 1
                ? Shot((float)60 / weapon.bulletsPerMinute, weapon.bulletType != BulletType.autoRifle)
                : Shot();
            StartCoroutine(shotRoutine);
        }

        if (Constants.IsMouseUp(0) && shotRoutine != null)
        {
            StopCoroutine(shotRoutine);
        }

        if (Constants.IsKeyDown("Reload"))
        {
            StartCoroutine(nameof(Reload));
        }
    }

    /// <summary>
    /// Создаёт необходимое количество пуль в зависимости от количества патронов, типа оружия и времени, прошедшего после создания предыдущей пули
    /// </summary>
    /// <param name="shotDelay">Задержка перед следующей пулей (Например у ПП, автоматов и т.д.)</param>
    /// <param name="once">Отсутствует ли стрельба по зажатию или нет</param>
    /// <returns></returns>
    private IEnumerator Shot(float shotDelay = 0, bool once = true)
    {
        if (bulletCount <= 0)
        {
            yield break;
        }

        if (once)
        {
            for (var i = 0; i < weapon.bulletsPerShot; i++)
            {
                SummonProjectile();
            }

            bulletCount--;
            yield break;
        }

        while (bulletCount > 0)
        {
            SummonProjectile();
            bulletCount--;
            yield return new WaitForSeconds(shotDelay);
        }
    }

    /// <summary>
    /// Корутина ждет время и восстанавливает патроны
    /// </summary>
    /// <returns></returns>
    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(Constants.RELOAD_TIME);
        bulletCount = maxBulletCount;
    }

    /// <summary>
    /// Вызывает из пула пулю и устанавливает ей определённые характеристики
    /// </summary>
    private void SummonProjectile()
    {
        var go = Pool.pools["rifleProjectile"].Get();
        var _projectile = go.GetComponent<Projectile>();
        _projectile.damage = weapon.bulletType switch
        {
            BulletType.pistol => 50,
            BulletType.shotgun => 10,
            BulletType.autoRifle => 30,
            BulletType.sniperRifle => 300,
            _ => 1
        };
        _projectile.angleSpread = weapon.angleSpread;
        _projectile.Launch();
    }
}