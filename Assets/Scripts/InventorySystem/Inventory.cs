using System;
using UnityEngine;

/// <summary>
/// Класс, полностью отвечающий за все действия с инвентарём
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject childPrefab;
    [SerializeField] private InventoryCell[] cells;
    public static Inventory _instance;
    private Combat _combat;
    public InventoryCell activeCell;

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
        _combat = FindAnyObjectByType<Combat>();
    }

    /// <summary>
    /// Возвращает клетку по ID
    /// </summary>
    /// <param name="id">ID клетки (<see cref="InventoryCell.ID"/>)</param>
    /// <returns><see cref="InventoryCell"/></returns>
    private InventoryCell GetCellById(int id)
    {
        if (id < 0 || id > cells.Length - 1)
        {
            throw new IndexOutOfRangeException("GetCellById: Out of range");
        }
        return cells[id];
    }

    private InventoryCell GetHotbarCellById(int id)
    {
        if (id is < 1 or > 8)
        {
            throw new IndexOutOfRangeException("GetHotbarCellById: Out of range");
        }
        return cells[27+id];
    }

    /// <summary>
    /// Меняет cell.item и _cell.item между собой
    /// </summary>
    /// <param name="cell">Первая клетка</param>
    /// <param name="_cell">Вторая клетка</param>
    public static void SwapCells(InventoryCell cell, InventoryCell _cell)
    {
        (cell.item, _cell.item) = (_cell.item, cell.item);
        cell.UpdateCell();
        _cell.UpdateCell();
    }

    /// <summary>
    /// Вручную изменяет предмет на новый в конкретной клетке
    /// </summary>
    /// <param name="cid">ID Клетки с предметом</param>
    /// <param name="item">Новый предмет</param>
    public void ChangeItemInCell(int cid, Item item)
    {
        GetCellById(cid).item = item;
        GetCellById(cid).UpdateCell();
    }

    private void Update()
    {
        if(Constants.IsKeyUp("Inventory"))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            activeCell = GetHotbarCellById(1);
            if(activeCell.item is Weapon item) 
                _combat.ChangeWeapon(item);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            activeCell = GetHotbarCellById(2);
            if(activeCell.item is Weapon item) 
                _combat.ChangeWeapon(item);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            activeCell = GetHotbarCellById(3);
            if(activeCell.item is Weapon item) 
                _combat.ChangeWeapon(item);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            activeCell = GetHotbarCellById(4);
            if(activeCell.item is Weapon item) 
                _combat.ChangeWeapon(item);
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            activeCell = GetHotbarCellById(5);
            if(activeCell.item is Weapon item) 
                _combat.ChangeWeapon(item);
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            activeCell = GetHotbarCellById(6);
            if(activeCell.item is Weapon item) 
                _combat.ChangeWeapon(item);
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            activeCell = GetHotbarCellById(7);
            if(activeCell.item is Weapon item) 
                _combat.ChangeWeapon(item);
        }
        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            activeCell = GetHotbarCellById(8);
            if(activeCell.item is Weapon item) 
                _combat.ChangeWeapon(item);
        }
    }
}
