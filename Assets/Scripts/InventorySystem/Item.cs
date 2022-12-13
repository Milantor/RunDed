using UnityEngine;

/// <summary>
/// Класс предмета, находящегося в инвентаре или другом хранилище
/// </summary>
public class Item
{
    /// <summary>
    /// ID предмета, даёт понять какой это именно тип предмета
    /// </summary>
    private string ID;
    /// <summary>
    /// (Только для чтения) ID предмета, даёт понять какой это именно тип предмета
    /// </summary>
    public string id { get => ID;}
    /// <summary>
    /// Спрайт иконки
    /// </summary>
    private Sprite sprite;
    /// <summary>
    /// (Только для чтения) Спрайт иконки
    /// </summary>
    public Sprite Sprite { get => sprite; }


    /// <summary>
    /// Конструктор класса <see cref="Item"/>
    /// </summary>
    /// <param name="_ID">ID предмета, даёт понять какой это именно тип предмета</param>
    public Item(string _ID = "none")
    {
        ID = _ID;
        sprite = null;
    }
    /// <summary>
    /// Конструктор класса <see cref="Item"/>
    /// </summary>
    /// <param name="_ID">ID предмета, даёт понять какой это именно тип предмета</param>
    /// <param name="_sprite">Спрайт иконки</param>
    public Item(string _ID, Sprite _sprite = null)
    {
        ID = _ID;
        sprite = _sprite;
    }

}
