using System.Collections.Generic;
/// <summary>
/// Словарь CODE:ID предметов
/// </summary>
public static class ItemIds
{
    public static Dictionary<string, string> ids = new Dictionary<string, string>();

    public const string NONE = "empty";
    public const string APPLE = "apple";

    public static void Start()
    {
        ids.Add("NONE", NONE);
        ids.Add("APPLE", APPLE);
    }

}
