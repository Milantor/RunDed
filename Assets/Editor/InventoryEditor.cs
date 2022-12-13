using UnityEditor;
using UnityEngine;
/// <summary>
/// ��������� ������ ��� ������ �������� ������
/// </summary>
[CustomEditor(typeof(Inventory))]
[CanEditMultipleObjects]
class InventoryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Give"))
            Inventory._instance.ChangeItemInCell();
    }
}