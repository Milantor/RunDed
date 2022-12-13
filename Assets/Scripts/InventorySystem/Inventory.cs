using UnityEngine;

/// <summary>
/// �����, ��������� ���������� �� ��� �������� � ���������
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] GameObject childPrefab;
    [SerializeField] InventoryCell[] cells;
    public static Inventory _instance;

    private void Start()
    {
        if (_instance != null)
            Debug.LogError("WATAFUKA? >1 Inventory.cs script ons scene? AWFUL");
        _instance = this;
        int i = 0;
        foreach(InventoryCell cell in cells)
        {
            cell.ID = i;
            GameObject _go = Instantiate(childPrefab, cell.transform);
            cell.UpdateCell();
            ++i;
        }
    }

    /// <summary>
    /// ���������� ������ �� ID
    /// </summary>
    /// <param name="ID">ID ������ (<see cref="InventoryCell.ID"/>)</param>
    /// <returns><see cref="InventoryCell"/></returns>
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

    /// <summary>
    /// ������ cell.item � _cell.item ����� �����
    /// </summary>
    /// <param name="cell">������ ������</param>
    /// <param name="_cell">������ ������</param>
    public void SwapCells(InventoryCell cell, InventoryCell _cell)
    {
        Item item = cell.item;
        cell.item = _cell.item;
        _cell.item = item;
        cell.UpdateCell();
        _cell.UpdateCell();
    }

    /// <summary>
    /// ������� �������� ������� �� ����� � ���������� ������
    /// </summary>
    /// <param name="CellId">ID ������ � ���������</param>
    /// <param name="ItemId">ID ������ ��������</param>
    /// <param name="ItemIcon">������ ��������</param>
    public void ChangeItemInCell(int CID, string IID)
    {
        GetCellById(CID).item = new Item(IID);
        GetCellById(CID).UpdateCell();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
}
