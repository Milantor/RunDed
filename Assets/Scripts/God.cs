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
    }
}