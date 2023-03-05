using UnityEngine;

/// <summary>
/// Класс предмета, находящегося в инвентаре или другом хранилище
/// </summary>
public class Item
{
    /// <summary>
    /// ID предмета, даёт понять какой это именно тип предмета
    /// </summary>
    public string id { get; }
    /// <summary>
    /// Спрайт иконки
    /// </summary>
    public Sprite sprite { get; }


    /// <summary>
    /// Конструктор класса <see cref="Item"/>
    /// </summary>
    /// <param name="id">ID предмета, даёт понять какой это именно тип предмета</param>
    public Item(string id = "empty")
    {
        this.id = id;
        sprite = ItemIcons.icons[id];
    }
}
