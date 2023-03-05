using System.Collections.Generic;
/// <summary>
/// —ловарь CODE:ID предметов
/// </summary>
public static class ItemIds // бл€ть а наху€ € это создал #TODO: уничтожить
{
    public static Dictionary<string, string> ids = new Dictionary<string, string>();

    public const string NONE = "empty";
    public const string APPLE = "apple";
    public const string FISH = "fish";
    public const string STONE = "stone";

    public static void Start()
    {
        if (!ids.ContainsKey("NONE"))
            ids.Add("NONE", NONE);
        if (!ids.ContainsKey("APPLE"))
            ids.Add("APPLE", APPLE);
        if (!ids.ContainsKey("FISH"))
            ids.Add("FISH", FISH);
        if (!ids.ContainsKey("STONE"))
            ids.Add("STONE", STONE);
    }
}