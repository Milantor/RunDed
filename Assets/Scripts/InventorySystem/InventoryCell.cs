using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Класс, отвечающий за физические объекты клеток инвентаря
/// </summary>
public class InventoryCell : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// Предмет, хранящийся в клетке
    /// </summary>
    public Item item;
    /// <summary>
    /// ID клетки
    /// </summary>
    public int ID;

    private Image _image;

    private void Start()
    {
        _image = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DraDr._instance.Click(this);
        Debug.Log(string.Format("Clicked cell id: {0}\nClicked item id: {1}", ID.ToString(), item.id));
    }

    /// <summary>
    /// Обновляет данные о клетке
    /// </summary>
    public void UpdateCell()
    {
        if (item == null)
        {
            item = new Item();
        }
        else
        {
            _image.sprite = ItemIcons.icons[item.id];
        }
    }
}