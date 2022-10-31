using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//этот скрипт отвечает за изменение спрайта персонажа и его деталей

public class Visual : MonoBehaviour
{

    public int walkState;
    private int animIndex;
    private Movement movement;
    [SerializeField] SpriteRenderer Weapon, Ded;
    [SerializeField] Sprite[] weaponSprites;
    [SerializeField] Sprite[] idleSprites;
    [SerializeField] Sprite[] walkSprites;
    [SerializeField] Sprite[] runSprites;
    
    public void Start()
    {
        Ded = GetComponent<SpriteRenderer>();
        movement = GetComponent<Movement>();
        walkState = 1;
        StartCoroutine(WalkAnimate());
    }
    public void ChangeWeaponSprite(int GunIndex)
    {
        Sprite sprite = weaponSprites[GunIndex];
        Weapon.sprite = sprite;
    }

    float oldx;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        #region rotate
        if (oldx != x)
            XRotate(x);
        oldx = x;
        #endregion
        if (movement.isRun)
            walkState = 2;
        else if (x != 0)
            walkState = 1;
        else walkState = 0;
    }

    public void XRotate(float x)
    {
        if (x < 0)
            Ded.flipX = true;
        if (x > 0)
            Ded.flipX = false;
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
                    Debug.Log("Suka shto ti kurish " + animIndex);
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
                    Debug.Log("Suka shto ti kurish " + animIndex);
                    yield return new WaitForSeconds(0.25f);
                    break;
            }
        }
    }
}