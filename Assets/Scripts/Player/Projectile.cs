using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Projectile : MonoBehaviour
{
	private Transform launchPosition, projectileTransform;
	private Vector3 position, right, direction;
	private Stats lastEnemy;
	public int damage { get; private set; }
	public float speed { get; private set; }

	private void Awake()
	{
		damage = Constants.DAMAGE;
		speed = Constants.SPEED;
		launchPosition = FindAnyObjectByType<Player>().GetComponent<Transform>().GetChild(0).GetChild(0).GetComponent<Transform>();
		projectileTransform = transform;
	}

	private void OnEnable()
	{
		Launch();
	}

	public void Launch()
	{
		projectileTransform.position = launchPosition.position;
		direction = Input.mousePosition - Camera.main.WorldToScreenPoint(projectileTransform.position);
		projectileTransform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
		StartCoroutine(nameof(deactive));
	}

	IEnumerator deactive()
	{
		yield return new WaitForSeconds(Constants.LIFE_TIME);
		gameObject.SetActive(false);
	}
	
	private RaycastHit2D hit;
	private void Update()
	{
		position = projectileTransform.position;
		right = projectileTransform.right;
		Debug.DrawRay(position, right, Color.red);
		hit = Physics2D.Raycast(position, right, 0.5f); // 0.5f - расстояние обнаружения пулей обьекта перед ней. Чем больше скорость пули тем больше должен быть этот параметр для нормальной работы
		transform.Translate(Vector3.right * ((speed + Random.Range(5, 3)) * 3 * Time.deltaTime));
		if (hit.collider is not null)
		{
			CollisionEnter(hit.collider);
		}
	}

	// public static Projectile CreateProjectile(Vector2 position, Vector2 direction, Sprite sprite, int Damage, float Speed)
	// {
	// 	go = new GameObject
	// 	{
	// 		transform =
	// 		{
	// 			position = position
	// 		}
	// 	};
	// 	sr = go.AddComponent<SpriteRenderer>();
	// 	go.AddComponent<BoxCollider2D>();
	// 	sr.sprite = sprite;
	// 	damage = Damage;
	// 	speed = Speed;
	// 	float Angle = 0;
	// 	Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
	// 	go.transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
	// 	go.AddComponent<CollisionCallback>().speed = speed;
	// 	go.GetComponent<CollisionCallback>().callback = new Action<Collider2D>(CollisionEnter);
	// }

	private void CollisionEnter(Component col)
	{
		lastEnemy = col.gameObject.GetComponent<Stats>();
		if(col.gameObject.GetComponent<Stats>())
			lastEnemy.GetDamage(damage);
	}
}