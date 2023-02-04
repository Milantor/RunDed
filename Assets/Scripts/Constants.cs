using System.Collections.Generic;
using UnityEngine;

using static UnityEngine.KeyCode;

public static class Constants
{
    // Player
        public const float DASH_TIME  = .3f;
        public const float DASH_SPEED = 10f;

        public const float JUMP_POWER = 250f;
        public const float MAX_WALK_ACCELERATION = 6f;
        public const float MAX_WALK_SPEED = 8f;

    // Control
    /// <summary>
    /// Нужен для назначения нескольких клавиш на одно действие
    /// </summary>
    private static Dictionary<string, List<KeyCode>> keysDefinitions = new()
    {
        {"Jump", new List<KeyCode>() { KeyCode.Space } },
        {"Dash", new List<KeyCode>() { LeftControl } },
    };
    public static bool IsKeyDown(string name)
    {
        var keys = keysDefinitions[name];
        foreach (var i in keys)
            if (Input.GetKeyDown(i))
                return true;
        return false;
    }
    public static bool IsKey(string name)
    {
        var keys = keysDefinitions[name];
        foreach (var i in keys)
            if (Input.GetKey(i))
                return true;
        return false;
    }
    public static bool IsKeyUp(string name)
    {
        var keys = keysDefinitions[name];
        foreach (var i in keys)
            if (Input.GetKeyUp(i))
                return true;
        return false;
    }
}
