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
            if (!Sprites.ContainsKey(sprite.name))
                Sprites.Add(sprite.name, sprite);
        }
        if (!icons.ContainsKey("apple"))
            icons.Add("apple", Sprites["apple"]);
        if (!icons.ContainsKey("empty"))
            icons.Add("empty", Sprites["empty"]);
        if (!icons.ContainsKey("fish"))
            icons.Add("fish", Sprites["fish"]);
        if (!icons.ContainsKey("stone"))
            icons.Add("stone", Sprites["stone"]);
    }
}