using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] InventoryCell[] cells;

    private void Start()
    {
        int i = 0;
        foreach(InventoryCell cell in cells)
        {
            cell.ID = i;
            ++i;
        }
    }

    public InventoryCell GetCellById(int ID)
    {
        if (ID < 0 || ID > (cells.Length - 1))
        {
            Debug.LogError("GetCellById: Out of range");
            return cells[0];
        }
        else
        {
            return cells[ID];
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
}
