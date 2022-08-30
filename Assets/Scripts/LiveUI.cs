using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveUI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    private void Start()
    {
       // player = FindObjectOfType<Movement>().GetComponent<Transform>();
    }
    void Update()
    {
        GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(target.position + offset);
    }

    //void OnBecameVisible()
    //{
    //    gameObject.SetActive(true);
    //}

    //void OnBecameInvisible()
    //{
    //    gameObject.SetActive(false);
    //}

    //IEnumerator UpdatePosition()
    //{
    //    float x = 0, y = 0;
    //    while (GetComponent<RectTransform>().anchoredPosition != (Vector2)Camera.main.WorldToScreenPoint(player.position + offset))
    //    {
    //        x = Mathf.Lerp(GetComponent<RectTransform>().anchoredPosition.x, Camera.main.WorldToScreenPoint(player.position + offset).x, 0.8f + Time.deltaTime);
    //        y = Mathf.Lerp(GetComponent<RectTransform>().anchoredPosition.y, Camera.main.WorldToScreenPoint(player.position + offset).y, 0.8f + Time.deltaTime);
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //    GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
    //}
}