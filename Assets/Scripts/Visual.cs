using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//этот скрипт отвечает за изменение спрайта персонажа в мире

public class Visual : MonoBehaviour
{

    Movement movement; //ссылка на скрипт движения
    SpriteRenderer spriteRenderer;

    int oldState = 1;

    [SerializeField]
    List<Sprite> walk;
    public bool isWalk;
    public int walkIndex;
    public GameObject Weapon;
    public Material m;
    public Transform Point;
    public Vector3 Difference;

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
        //StartCoroutine(TrailSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        Difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - Weapon.transform.position;
        float RotateZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;
        Weapon.transform.rotation = Quaternion.Slerp(Weapon.transform.rotation, Quaternion.Euler(0, 0, RotateZ), 0.5f);
    }

    IEnumerator TrailSpawner()
    {
        while (movement.inDash)
        {
            GetComponent<Attack>().Shot(ProjectileType.trail);
            yield return new WaitForSeconds(0.005f);
        }
    }

    IEnumerator Animate(List<Sprite> sprites, float seconds)
    {
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
                //Weapon.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
                //if (oldState != 1)
                //{
                //    Transform wpno = Weapon.transform;
                //    wpno.localPosition = new Vector3(-Mathf.Abs(-wpno.localPosition.x), Mathf.Abs(wpno.localPosition.y), Mathf.Abs(wpno.localPosition.z));
                //    Point.localPosition = new Vector3(Mathf.Abs(-Point.localPosition.x), Mathf.Abs(Point.localPosition.y), Mathf.Abs(Point.localPosition.z));
                //    oldState = 1;
                //}
                StopAllCoroutines();
                if (!isWalk)
                    StartCoroutine(Animate(walk, 0.1f));
                isWalk = true;
                break;
            case < 0:
                spriteRenderer.flipX = true;
                //Weapon.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
                //if (oldState != -1)
                //{
                //    Transform wpno = Weapon.transform;
                //    wpno.localPosition = new Vector3(Mathf.Abs(-wpno.localPosition.x), Mathf.Abs(wpno.localPosition.y), Mathf.Abs(wpno.localPosition.z));
                //    Point.localPosition = new Vector3(-Mathf.Abs(-Point.localPosition.x), Mathf.Abs(Point.localPosition.y), Mathf.Abs(Point.localPosition.z));
                //    oldState = -1;
                //}
                StopAllCoroutines();
                if (!isWalk)
                    StartCoroutine(Animate(walk, 0.1f));
                isWalk = true;
                break;
            case 0:
                    StopAllCoroutines();
                    isWalk = false;
                break;
        }
    }
}