using System.Collections.Generic;
/// <summary>
/// Словарь CODE:ID предметов
/// </summary>
public static class ItemIds
{
    public static Dictionary<string, string> ids = new Dictionary<string, string>();

    public const string RIFLE = "RD:ak74";

    public static void Start()
    {
        ids.Add("RIFLE", RIFLE);
    }

}
