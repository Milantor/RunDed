using UnityEditor;
using UnityEngine;
/// <summary>
/// Добавляет кнопку для выдачи предмета читами
/// </summary>
[CustomEditor(typeof(God))]
[CanEditMultipleObjects]
class GodEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Give"))
            Inventory._instance.ChangeItemInCell(God._instance.CellId, God._instance.ItemId);
    }
}