using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//этот скрипт отвечает за изменение спрайта персонажа и его деталей

public class Visual : MonoBehaviour
{

    public bool AutoWalk;
    public int walkState;
    private int animIndex;
    private Movement movement;
    [SerializeField] SpriteRenderer Weapon, Ded;
    [SerializeField] Sprite[] weaponSprites;
    [SerializeField] Sprite[] idleSprites, layIdleSprites, crIdleSprites;
    [SerializeField] Sprite[] walkSprites, layWalkSprites, crWalkSprites;
    [SerializeField] Sprite[] runSprites;
    [SerializeField] Sprite[] toCr, toLay;
    [SerializeField] private float toAnimTime;

    public void Start()
    {
        Ded = GetComponent<SpriteRenderer>();
        movement = GetComponent<Movement>();
        walkState = 1;
        AutoWalk = true;
        Weapon.sprite = null;
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

    public void ToCr()
    {
        AutoWalk = false;
        StopCoroutine(Lay());
        StartCoroutine(Cr());
    }

    IEnumerator Cr()
    {
        int count = toCr.Length;
        int state = 0;
        while (count > state)
        {
            Ded.sprite = toCr[state];
            state++;
            yield return new WaitForSeconds(toAnimTime / toCr.Length);
        }
        AutoWalk = true;
        StopCoroutine(Cr());
    }

    public void ToLay()
    {
        AutoWalk = false;
        StopCoroutine(Cr());
        StartCoroutine(Lay());
    }

    IEnumerator Lay()
    {
        int count = toLay.Length;
        int state = 0;
        while (count > state)
        {
            Ded.sprite = toLay[state];
            state++;
            yield return new WaitForSeconds(toAnimTime / toLay.Length);
        }
        AutoWalk = true;
        StopCoroutine(Lay());
    }

    IEnumerator WalkAnimate()
    {
        for (; ; )
        {
            if (AutoWalk)
            {
                switch (walkState)
                {
                    case 0: //idle
                        int mainCount;
                        if (movement.isLayed)
                        {
                            if (layIdleSprites.Length - 1 >= animIndex)
                                Ded.sprite = layIdleSprites[animIndex];
                            else
                                Ded.sprite = layIdleSprites[0];
                            mainCount = layIdleSprites.Length;
                        }
                        else if (movement.isCrought)
                        {
                            if (crIdleSprites.Length - 1 >= animIndex)
                                Ded.sprite = crIdleSprites[animIndex];
                            else
                                Ded.sprite = crIdleSprites[0];
                            mainCount = crIdleSprites.Length;
                        }
                        else
                        {
                            if (idleSprites.Length - 1 >= animIndex)
                                Ded.sprite = idleSprites[animIndex];
                            else
                                Ded.sprite = idleSprites[0];
                            mainCount = idleSprites.Length;
                        }
                        animIndex = (animIndex > (mainCount - 2)) ? 0 : ++animIndex;
                     //   Debug.Log("Suka shto ti kurish " + animIndex);
                        yield return new WaitForSeconds(0.25f);
                        break;
                    case 1: // walk
                        if (movement.isLayed)
                        {
                            if (layWalkSprites.Length - 1 >= animIndex)
                                Ded.sprite = layWalkSprites[animIndex];
                            else
                                Ded.sprite = layWalkSprites[0];
                            mainCount = layWalkSprites.Length;
                        }
                        else if (movement.isCrought)
                        {
                            if (crWalkSprites.Length - 1 >= animIndex)
                                Ded.sprite = crWalkSprites[animIndex];
                            else
                                Ded.sprite = crWalkSprites[0];
                            mainCount = crWalkSprites.Length;
                        }
                        else
                        {
                            if (walkSprites.Length - 1 >= animIndex)
                                Ded.sprite = walkSprites[animIndex];
                            else
                                Ded.sprite = walkSprites[0];
                            mainCount = walkSprites.Length;
                        }
                        animIndex = (animIndex > mainCount - 2) ? 0 : ++animIndex;
                       // Debug.Log("Suka shto ti kurish " + animIndex);
                        yield return new WaitForSeconds(0.25f);
                        break;
                    case 2: // run
                        if (movement.isLayed)
                        {
                            if (layWalkSprites.Length - 1 >= animIndex)
                                Ded.sprite = layWalkSprites[animIndex];
                            else
                                Ded.sprite = layWalkSprites[0];
                            mainCount = layWalkSprites.Length;
                        }
                        else if (movement.isCrought)
                        {
                            if (crWalkSprites.Length - 1 >= animIndex)
                                Ded.sprite = crWalkSprites[animIndex];
                            else
                                Ded.sprite = crWalkSprites[0];
                            mainCount = crWalkSprites.Length;
                        }
                        else
                        {
                            if (runSprites.Length - 1 >= animIndex)
                                Ded.sprite = runSprites[animIndex];
                            else
                                Ded.sprite = runSprites[0];
                            mainCount = runSprites.Length;
                        }
                        animIndex = (animIndex > mainCount - 2) ? 0 : ++animIndex;
                       // Debug.Log("Suka shto ti kurish " + animIndex);
                        yield return new WaitForSeconds(0.25f);
                        break;
                }
            }
            else
                yield return new WaitForSeconds(toAnimTime);
        }
    }
}