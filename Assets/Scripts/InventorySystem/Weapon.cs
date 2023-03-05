public enum BulletType
{
	shotgun,
	pistol,
	autoRifle,
	sniperRifle
}

public class Weapon : Item
{
	public BulletType bulletType { get; }
	public  int magazineSize { get; }
	public int bulletsPerShot { get; }
	public int bulletsPerMinute { get; }
	public int angleSpread { get; }
	public float speedSpread { get; }
	public Weapon(string id, BulletType bulletType, int magazineSize, int bulletsPerShot, int bulletsPerMinute, int angleSpread, float speedSpread) : base(id)
	{
		this.bulletType = bulletType;
		this.magazineSize = magazineSize;
		this.bulletsPerShot = bulletsPerShot > 0 ? bulletsPerShot : 1;
		this.bulletsPerMinute = bulletsPerMinute;
		this.angleSpread = angleSpread;
		this.speedSpread = speedSpread;
	}
}
