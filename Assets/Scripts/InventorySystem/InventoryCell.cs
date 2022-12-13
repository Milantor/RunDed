using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// �����, ���������� �� ���������� ������� ������ ���������
/// </summary>
public class InventoryCell : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// �������, ���������� � ������
    /// </summary>
    public Item item;
    /// <summary>
    /// ID ������
    /// </summary>
    public int ID;

    public void OnPointerClick(PointerEventData eventData)
    {
        DraDr._instance.Click(this);
        Debug.Log("Clicked cell id: " + ID + "\nClicked item id: " + item.id);
    }

    /// <summary>
    /// ��������� ������ � ������
    /// </summary>
    public void UpdateCell()
    {
        if (item == null)
        {
            item = new Item();
        }
        else
        {
            transform.GetChild(0).GetComponent<Image>().sprite = ItemIcons.icons[item.id];
        }
    }
}