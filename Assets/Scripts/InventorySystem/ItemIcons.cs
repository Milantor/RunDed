using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Ñëîâàðü ID:Sprite ïðåäìåòîâ
/// </summary>
public static class ItemIcons
{
    public static Dictionary<string, Sprite> icons = new();
    private static Dictionary<string, Sprite> Sprites = new();
    private static Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/Sprites");
    private static Sprite[] weapons = Resources.LoadAll<Sprite>("Sprites/weapons");
    private static Sprite[] newWeapons = Resources.LoadAll<Sprite>("Sprites/weapons4.4");
    public static void Start()
    {
        foreach (var sprite in sprites)
        {
            if (!Sprites.ContainsKey(sprite.name))
                Sprites.Add(sprite.name, sprite);
        }
        foreach (var sprite in weapons)
        {
            if (!Sprites.ContainsKey(sprite.name))
                Sprites.Add(sprite.name, sprite);
        }
        foreach (var sprite in newWeapons)
        {
            if (!Sprites.ContainsKey(sprite.name))
                Sprites.Add(sprite.name, sprite);
        }
        // тупая реализация, хз какая у вас архитектура //иди нахуй
        foreach (var icon in new string[] {"apple", "empty", "fish", "stone", "pistol", "gun", "auto", "sniper"}){
            if (!icons.ContainsKey(icon)){
                icons.Add(icon, Sprites[icon]);
            }
        }
        /*if (!icons.ContainsKey("apple"))
            icons.Add("apple", Sprites["apple"]);
        if (!icons.ContainsKey("empty"))
            icons.Add("empty", Sprites["empty"]);
        if (!icons.ContainsKey("fish"))
            icons.Add("fish", Sprites["fish"]);
        if (!icons.ContainsKey("stone"))
            icons.Add("stone", Sprites["stone"]);
        if (!icons.ContainsKey("rifle"))
            icons.Add("rifle", Sprites["rifle"]);*/
        
    }
}
