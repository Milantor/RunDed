using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class God : MonoBehaviour
{
    public static God _instance;
    public int cellId;
    public string itemId;

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
            Inventory._instance.ChangeItemInCell(Random.Range(36, 44), "APPLE");
            Inventory._instance.ChangeItemInCell(Random.Range(36, 44), "APPLE");
        }
    }
}