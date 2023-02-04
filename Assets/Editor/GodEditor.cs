using UnityEditor;
using UnityEngine;
/// <summary>
/// Добавляет кнопку для выдачи предмета читами
/// </summary>
[CustomEditor(typeof(God))]
[CanEditMultipleObjects]
internal class GodEditor : Editor
{
    private Inventory _instance;
    public void Start()
    {
	    _instance = Inventory._instance;
    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Give"))
            _instance.ChangeItemInCell(God._instance.cellId, God._instance.itemId);
    }
}