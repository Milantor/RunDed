using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile
{
	public GameObject go { get; }
	public SpriteRenderer sr { get; }
	public int damage { get; }
	public float speed { get; }

	public Projectile(Vector2 position, Vector2 direction, Sprite sprite, int Damage, float Speed)
	{
		go = new GameObject
		{
			transform =
			{
				position = position
			}
		};
		sr = go.AddComponent<SpriteRenderer>();
		go.AddComponent<BoxCollider2D>();
		sr.sprite = sprite;
		damage = Damage;
		speed = Speed;
		float Angle = 0;
		Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		go.transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
		go.AddComponent<CollisionCallback>().speed = speed;
		go.GetComponent<CollisionCallback>().callback = new Action<Collider2D>(CollisionEnter);
	}

	private void CollisionEnter(Collider2D collider2D)
	{
		collider2D.gameObject.GetComponent<Stats>().GetDamage(damage);
	}
}