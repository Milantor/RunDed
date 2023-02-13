using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


//#TODO: Сделать автономным чтобы работало от скрипта Stats;
public class EnemyHpBar : MonoBehaviour
{
    public Vector3 barOffset;
    public List<Stats> statses;
    public List<GameObject> gos;
    private Dictionary<Stats, GameObject> table;
    private Camera _camera;
    private void Start()
    {
        table = statses.Zip(gos, (k, v) => new { k, v })
            .ToDictionary(x => x.k, x => x.v);
        _camera = Camera.main;
        BarsUpdate();
    }

    private void Update()
    {
        foreach (var stats in table)
        {
            stats.Value.transform.position = (_camera.WorldToScreenPoint(stats.Key.transform.position) + barOffset*Screen.width/1366);
        }
    }

    public void BarsUpdate()
    {
        foreach (var stats in table)
        {
            var stat = stats.Key;
            var bar = stats.Value;
            bar.transform.GetChild(2).GetComponent<Image>().fillAmount = (float)stat.Hp / 1000; //#TODO: ПЕРЕДЕЛАТЬ НА НОРМАЛЬНОЕ
            bar.GetComponentInChildren<Text>().text = stat.Hp + " / 1000";
        }
    }
}
