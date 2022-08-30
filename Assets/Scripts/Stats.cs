using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsTools
{
    Remove = 0,
    Add = 1
}

public class Stats : MonoBehaviour
{
    public float HP;
    public float Armor;
    [SerializeField] bool isPlayer;

    public void SetHP(float hp)
    {
        HP = hp;
    }

    public void ChangeHp(float hp, StatsTools statTool = StatsTools.Remove)
    {
        if (hp > Armor)
        {
            if ((statTool == StatsTools.Remove || statTool == StatsTools.Add))
                switch (statTool)
                {
                    case StatsTools.Remove:
                        HP += Armor - (Mathf.Abs(hp));
                        Debug.Log("“–¿’Õ”“Œ");
                        if (HP <= 0)
                        {
                            switch (isPlayer == true)
                            {
                                case true:
                                    Debug.Log("“€ “–”œ");
                                    break;
                                case false:
                                    Debug.Log("Ú˚ ÍÓ„Ó-ÚÓ ÛÂ·‡Î");
                                    break;
                            }
                        }
                        break;
                    case StatsTools.Add:
                        HP += Mathf.Abs(hp);
                        break;
                }
        }
    }
}