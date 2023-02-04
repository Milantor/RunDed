using System;
using UnityEngine;

/// <summary>
/// �����, ��������� ���������� �� ��� �������� � ���������
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject childPrefab;
    [SerializeField] private InventoryCell[] cells;
    public static Inventory _instance;

    private void Start()
    {
        if (_instance != null)
            throw new StackOverflowException("WATAFUKA? >1 Inventory.cs script ons scene? AWFUL");
        _instance = this;
        var i = 0;
        foreach(var cell in cells)
        {
            cell.ID = i;
            var _go = Instantiate(childPrefab, cell.transform);
            cell.UpdateCell();
            ++i;
        }
    }

    /// <summary>
    /// ���������� ������ �� ID
    /// </summary>
    /// <param name="id">ID ������ (<see cref="InventoryCell.ID"/>)</param>
    /// <returns><see cref="InventoryCell"/></returns>
    private InventoryCell GetCellById(int id)
    {
        if (id < 0 || id > (cells.Length - 1))
        {
            throw new IndexOutOfRangeException("GetCellById: Out of range");
        }
        return cells[id];
    }

    /// <summary>
    /// ������ cell.item � _cell.item ����� �����
    /// </summary>
    /// <param name="cell">������ ������</param>
    /// <param name="_cell">������ ������</param>
    public static void SwapCells(InventoryCell cell, InventoryCell _cell)
    {
        (cell.item, _cell.item) = (_cell.item, cell.item);
        cell.UpdateCell();
        _cell.UpdateCell();
    }

    /// <summary>
    /// ������� �������� ������� �� ����� � ���������� ������
    /// </summary>
    /// <param name="cid">ID ������ � ���������</param>
    /// <param name="iid">ID ������ ��������</param>
    public void ChangeItemInCell(int cid, string iid)
    {
        GetCellById(cid).item = new Item(iid);
        GetCellById(cid).UpdateCell();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
}
