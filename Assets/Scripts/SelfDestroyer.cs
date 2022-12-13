using System.Collections;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(KS());
    }
    IEnumerator KS()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
