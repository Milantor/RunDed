using System;
using System.Collections;
using System.Collections.Generic;
//не готово. не знаю как сделать и поэтому забил хуй
public class Pool
{
	//public static Dictionary<string, List<Type>> pools; //TODO: Add a normal pool create
	public static List<Pool> pools { get; }
	private string _name;
	private IList _objects;

	public Pool(string name, object _object)
	{
		foreach (Pool pool in pools)
		{
			if (pool._name == name)
			{
				throw new OverflowException("Пул с таким именем уже существует");
			}
		}
		_name = name;
		_objects = createList(_object.GetType());
		_objects.Add(_object);
		AddPool(this);
	}

	private static void AddPool(Pool pool)
	{
		pools.Add(pool);
	}
	
	private IList createList(Type myType)
	{
		Type genericListType = typeof(List<>).MakeGenericType(myType);
		return (IList)Activator.CreateInstance(genericListType);
	}
}
