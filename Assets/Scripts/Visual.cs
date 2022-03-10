using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//этот скрипт отвечает за изменение спрайта персонажа в мире

public class Visual : MonoBehaviour
{

    Movement movement; //ссылка на скрипт движения
    SpriteRenderer spriteRenderer;

    int oldState;

    [SerializeField]
    List<Sprite> walk;
    public bool isWalk;
    public int walkIndex;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        oldState = 0;
        if (walk == null)
        {
            walk = new List<Sprite>();
            walkIndex = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Animate(List<Sprite> sprites, float seconds)
    {
        Debug.Log("Coroutine started from coroutine");
        while (walkIndex < sprites.Count)
        {
            spriteRenderer.sprite = sprites[walkIndex];
            yield return new WaitForSeconds(seconds);
            ++walkIndex;
        }
        walkIndex = 0;
        StartCoroutine(Animate(walk, 0.1f));
        isWalk = true;
    }

    public void SpeedChanged(float speed)
    {
        switch (speed)
        {
            case > 0:
                spriteRenderer.flipX = false;
                if (oldState != 1)
                {
                    StopAllCoroutines();
                    Debug.Log("Coroutine stopped");
                    oldState = 1;
                    if (!isWalk)
                        StartCoroutine(Animate(walk, 0.25f));
                    isWalk = true;
                }
                break;
            case < 0:
                spriteRenderer.flipX = true;
                if (oldState != -1)
                {
                    StopAllCoroutines();
                    Debug.Log("Coroutine stopped");
                    oldState = -1;
                    if (!isWalk)
                        StartCoroutine(Animate(walk, 0.25f));
                    isWalk = true;
                }
                break;
            case 0:
                if (oldState != 0)
                {
                    StopAllCoroutines();
                    Debug.Log("Coroutine stopped");
                    oldState = 0;
                    isWalk = false;
                }
                break;
        }
    }
}