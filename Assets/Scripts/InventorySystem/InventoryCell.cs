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

    private Image _image;

    public void OnPointerClick(PointerEventData eventData)
    {
        DraDr._instance.Click(this);
        Debug.Log(string.Format("Clicked cell id: {0}\nClicked item id: {1}", ID.ToString(), item.id));
    }

    // ReSharper disable Unity.PerformanceAnalysis
    /// <summary>
    /// ��������� ������ � ������
    /// </summary>
    public void UpdateCell()
    {
        _image = transform.GetChild(0).GetComponent<Image>();
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