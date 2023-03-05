using UnityEngine;

/// <summary>
/// ����� ��������, ������������ � ��������� ��� ������ ���������
/// </summary>
public class Item
{
    /// <summary>
    /// ID ��������, ��� ������ ����� ��� ������ ��� ��������
    /// </summary>
    public string id { get; }
    /// <summary>
    /// ������ ������
    /// </summary>
    public Sprite sprite { get; }


    /// <summary>
    /// ����������� ������ <see cref="Item"/>
    /// </summary>
    /// <param name="id">ID ��������, ��� ������ ����� ��� ������ ��� ��������</param>
    public Item(string id = "empty")
    {
        this.id = id;
        sprite = ItemIcons.icons[id];
    }
}
