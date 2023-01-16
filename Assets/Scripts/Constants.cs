using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using static UnityEngine.KeyCode;

public static class Constants
{
    // Player
        public static float dashTime = .3f;
        public static float dashSpeed = 10f;

        public static float jumpPower = 250f;

        public static float maxWalkAcceleration = 6f;
        public static float maxWalkSpeed = 8f;

    // Control
    public static Dictionary<string, List<KeyCode>> keysDefenitions = new()
    {
        {"Jump", new List<KeyCode>() { KeyCode.Space } },
        {"Dash", new List<KeyCode>() { LeftControl } },
    };
    public static bool IsKeyDown(string name)
    {
        var keys = keysDefenitions[name];
        foreach (var i in keys)
            if (Input.GetKeyDown(i))
                return true;
        return false;
    }
    public static bool IsKey(string name)
    {
        var keys = keysDefenitions[name];
        foreach (var i in keys)
            if (Input.GetKey(i))
                return true;
        return false;
    }
    public static bool IsKeyUp(string name)
    {
        var keys = keysDefenitions[name];
        foreach (var i in keys)
            if (Input.GetKeyUp(i))
                return true;
        return false;
    }
}
