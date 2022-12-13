using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Словарь ID:Sprite предметов
/// </summary>
public static class ItemIcons
{
    public static Dictionary<string, Sprite> icons = new Dictionary<string, Sprite>();
    private static Dictionary<string, Sprite> Sprites = new Dictionary<string, Sprite>();
    private static Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/Sprites");
    public static void Start()
    {
        foreach (Sprite sprite in sprites)
        {
            Sprites.Add(sprite.name, sprite);
        }
        icons.Add("apple", Sprites["apple"]);
        icons.Add("empty", Sprites["empty"]);
    }

}