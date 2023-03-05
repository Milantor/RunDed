using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class God : MonoBehaviour
{
    public static God _instance;
    public int cellId;
    public string itemId;
    [Header("Only for Weapon")]
    public BulletType bulletType;
    public int magazineSize;
    public int bulletsPerShot;
    public int bulletsPerMinute;
    public int angleSpread;
    public float speedSpread;

    private void Start()
    {
        if (_instance != null)
        {
            throw new StackOverflowException("ONLY 1 GOD MAY STAYIN ALIVE");
        }
        _instance = this;
        ItemIds.Start();
        ItemIcons.Start();
        Invoke(nameof(TimeS), 0.5f);
    }

    private void TimeS()
    {
        var i = Random.Range(1, 4);
        for (var j = 0; j < i; j++)
        {
            Inventory._instance.ChangeItemInCell(28, new Weapon("apple",BulletType.pistol,9,1,200,30,0));
            Inventory._instance.ChangeItemInCell(29, new Weapon("apple",BulletType.shotgun,8,10,300,40,0));
            Inventory._instance.ChangeItemInCell(30, new Weapon("apple",BulletType.autoRifle,30,1,500,20,0));
            Inventory._instance.ChangeItemInCell(31, new Weapon("apple",BulletType.sniperRifle,10,1,100,1,0));
        }
    }
}