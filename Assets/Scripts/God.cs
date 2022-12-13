using UnityEngine;

public class God : MonoBehaviour
{
    public static God _instance;
    [Header("ItemGiver")]
    public int CellId;
    public string ItemId;

    private void Start()
    {
        if (_instance != null)
            Debug.LogError("ONLY 1 GOD MAY STAYN ALIVE");
        _instance = this;
        ItemIds.Start();
        ItemIcons.Start();
        Invoke("TimeS", 0.5f);
    }

    private void TimeS()
    {
        int i = Random.Range(1, 4);
        for (int j = 0; j < i; j++)
        {
        Inventory._instance.ChangeItemInCell(Random.Range(36, 44), "APPLE");
        Inventory._instance.ChangeItemInCell(Random.Range(36, 44), "APPLE");
        }
    }
}