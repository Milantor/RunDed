using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//этот скрипт отвечает за изменение спрайта персонажа и его деталей

public class Visual : MonoBehaviour
{

    public int walkState;
    [SerializeField] SpriteRenderer Weapon, Ded;
    [SerializeField] Sprite[] weaponSprites;
    [SerializeField] Sprite[] idleSprites;
    [SerializeField] Sprite[] walkSprites;
    [SerializeField] Sprite[] runSprites;
    private int animIndex;
    
    public void Start()
    {
        Ded = GetComponent<SpriteRenderer>();
        walkState = 1;
        StartCoroutine(WalkAnimate());
    }
    public void ChangeWeaponSprite(int GunIndex)
    {
        Sprite sprite = weaponSprites[GunIndex];
        Weapon.sprite = sprite;
    }

    IEnumerator WalkAnimate()
    {
        for(; ; )
        {
            switch (walkState)
            {
                case 0: //idle
                    Ded.sprite = idleSprites[animIndex];
                    animIndex = (animIndex > 6) ? 0 : ++animIndex;
                    yield return new WaitForSeconds(0.25f);
                    break;
                case 1: // walk
                    Ded.sprite = walkSprites[animIndex];
                    animIndex = (animIndex > 6) ? 0 : ++animIndex;
                    Debug.Log("Suka shto ti kurish " + animIndex);
                    yield return new WaitForSeconds(0.25f);
                    break;
                case 2: // run
                    Ded.sprite = runSprites[animIndex];
                    animIndex = (animIndex > 6) ? 0 : ++animIndex;
                    yield return new WaitForSeconds(0.25f);
                    break;
            }
        }
    }
}