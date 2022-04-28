using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarsManager : MonoBehaviour
{
    [SerializeField] Image reloadBar;

    Attack Attack;

    private void Start()
    {
        Attack = FindObjectOfType<Attack>();
    }

    public void UpdateBar(string Bar)
    {
        switch (Bar)
        {
            case "Reload":
                StartCoroutine(ReloadBar(Attack.ReloadTime));
                break;
        }
    }

    public void Stop()
    {
        StopAllCoroutines();
        reloadBar.fillAmount = 0;
    }

    IEnumerator ReloadBar(float seconds)
    {
        float timer = seconds;
        while (timer > 0)
        {
            reloadBar.fillAmount = (seconds - timer) / timer;
            timer -= Time.deltaTime;
            yield return null;
        }
        reloadBar.fillAmount = 0;
    }
}