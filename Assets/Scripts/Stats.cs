using System;
using UnityEngine;

public class Stats : MonoBehaviour
{
	private static int entityMaxId;
	public int entityId = entityMaxId;

	public int Hp { get; private set; }

	private void Start()
	{
		entityMaxId++;
		if (Hp == 0) Hp = 1000;
	}

	public int GetDamage(int damage)
	{
		if (Hp - damage <= 0) {
			Hp = 0;
			Death();
			return 0;
		}
		#region
		Hp -= damage;
		return Hp;
		#endregion
	}

	private void Death()
	{
		
		
	}
}