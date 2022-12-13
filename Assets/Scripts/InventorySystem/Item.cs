using UnityEngine;

/// <summary>
/// ����� ��������, ������������ � ��������� ��� ������ ���������
/// </summary>
public class Item
{
    /// <summary>
    /// ID ��������, ��� ������ ����� ��� ������ ��� ��������
    /// </summary>
    private string ID;
    /// <summary>
    /// (������ ��� ������) ID ��������, ��� ������ ����� ��� ������ ��� ��������
    /// </summary>
    public string id { get => ID;}
    /// <summary>
    /// ������ ������
    /// </summary>
    private Sprite sprite;
    /// <summary>
    /// (������ ��� ������) ������ ������
    /// </summary>
    public Sprite Sprite { get => sprite; }


    /// <summary>
    /// ����������� ������ <see cref="Item"/>
    /// </summary>
    /// <param name="_ID">ID ��������, ��� ������ ����� ��� ������ ��� ��������</param>
    public Item(string _ID = "NONE")
    {
        ID = ItemIds.ids[_ID];
        sprite = ItemIcons.icons[ID];
    }
}
