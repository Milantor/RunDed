using JetBrains.Annotations;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public static GameObject Instantiate(GameObject go, [CanBeNull] Transform position, [CanBeNull] Transform rotation)
    {
        return Instantiate(go, position, rotation);
    }
}
