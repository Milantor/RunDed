using System;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayerUI : MonoBehaviour
{
	private Combat _combat;
	[SerializeField] private Text text;
	private void Start()
	{
		_combat = GetComponent<Combat>();
	}

	private void Update()
	{
		text.text = _combat.bulletCount + "/" + _combat.maxBulletCount;
	}
}
