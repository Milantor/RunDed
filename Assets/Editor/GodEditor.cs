using UnityEditor;
using UnityEngine;
/// <summary>
/// Добавляет кнопку для выдачи предмета читами
/// </summary>
[CustomEditor(typeof(God))]
[CanEditMultipleObjects]
internal class GodEditor : Editor
{
    private Inventory _inventory;
    private God _god;
    public void Start()
    {
	    _inventory = Inventory._instance;
        _god = God._instance;   
    }
    public override void OnInspectorGUI()
    {
        if(_god is null || _inventory is null)
            Start();
        DrawDefaultInspector();
        if (GUILayout.Button("Give Item"))
            _inventory.ChangeItemInCell(_god.cellId, new Item(_god.itemId));
        if (GUILayout.Button("Give Weapon"))
            _inventory.ChangeItemInCell(_god.cellId, 
                new Weapon(
                    _god.itemId,
                    _god.bulletType,
                    _god.magazineSize,
                    _god.bulletsPerShot,
                    _god.bulletsPerMinute,
                    _god.angleSpread,
                    _god.speedSpread)
                );
    }
}