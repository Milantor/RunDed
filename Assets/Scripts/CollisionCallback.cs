using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class CollisionCallback : MonoBehaviour
{
	public Action<Collider2D> callback;
	public float speed;
	public LayerMask layer;

	void Update()
	{
		var transform1 = transform;
		var position = transform1.position;
		var right = transform1.right;
		Debug.DrawRay(position, right, Color.red);
		RaycastHit2D hit = Physics2D.Raycast(position, right, 0.5f); // 0.5f - расстояние обнаружения пулей обьекта перед ней. Чем больше скорость пули тем больше должен быть этот параметр для нормальной работы
		transform.Translate(Vector3.right * ((speed + Random.Range(5, 3)) * 3 * Time.deltaTime));
		if (hit.collider is not null)
		{
			if (hit.collider.GetComponent<Stats>())
			{
				callback(hit.collider);
				Destroy(gameObject);
			}
			
			Debug.Log(hit.collider.name);
		}
	}
}
