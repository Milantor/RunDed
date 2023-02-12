using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//TODO: Сделать универсальный пул для любых объектов
/// <summary>
/// GameObject Pool
/// </summary>
public class Pool
{
	//public static Dictionary<string, List<Type>> pools; //TODO: Add a normal pool create
	public static Dictionary<string,Pool> pools { get; private set; }
	public List<GameObject> data { get; }

	public Pool(GameObject firstObject)
	{
		GameObject _go = Instantiator.Instantiate(firstObject);
		data = new List<GameObject> { _go };
	}

	public static void New(string poolName, GameObject go)
	{
		pools ??= new Dictionary<string, Pool>();
		if (!pools.ContainsKey(poolName))
		{
			Debug.Log("New pool initialized");
			pools.Add(poolName, new Pool(go));
		}
		else throw new OverflowException("This key is already assigned");
	}

	public GameObject Get()
	{
		foreach (var go in data.Where(go => !go.activeSelf))
		{
			go.SetActive(true);
			return go;
		}
		var dataObj = Instantiator.Instantiate(data[0]);
		data.Add(dataObj);
		data[^1].SetActive(true);
		return data[^1];
	}
}
