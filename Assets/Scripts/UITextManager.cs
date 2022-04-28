using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextManager : MonoBehaviour
{
   [SerializeField] Text BulletText;
    Attack Attack;

    private void Start()
    {
        Attack = FindObjectOfType<Attack>();
        UpdateText("Bullet");
    }

    public void UpdateText(string Text)
    {
        switch (Text)
        {
            case "Bullet":
                BulletText.text = Attack.inGunBulletsCount + "/" + Attack.bulletsCount;
                break;
        }
    }
}
