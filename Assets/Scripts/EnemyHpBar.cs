using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour
{
    private Stats cc;
    public Image _image;
    public Text text;
    private void Start()
    {
        cc = GetComponent<Stats>();
    }

    private void Update()
    {
        _image.fillAmount = (float)cc.Hp / 1000;
        text.text = cc.Hp.ToString() + " / 1000";
    }
}
