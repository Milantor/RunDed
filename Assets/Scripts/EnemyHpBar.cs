using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


//#TODO: Сделать автономным чтобы работало от скрипта Stats;
public class EnemyHpBar : MonoBehaviour
{
    public List<Stats> statses;
    public List<GameObject> gos;
    private Dictionary<Stats, GameObject> table;
    private void Start()
    {
        table = statses.Zip(gos, (k, v) => new { k, v })
            .ToDictionary(x => x.k, x => x.v);

    }
    
    public void BarsUpdate()
    {
        foreach (var stats in table)
        {
            var stat = stats.Key;
            var bar = stats.Value;
            bar.GetComponentInChildren<Image>().fillAmount = (float)stat.Hp / 1000;
            bar.GetComponentInChildren<Text>().text = stat.Hp + " / 1000";
        }
    }
}
