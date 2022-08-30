using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mannequin : MonoBehaviour
{
    public GameObject Window;
    private void Start()
    {
        GetComponent<Interact>().link = Interact;
    }
    public void Interact()
    {
        Window.SetActive(!Window.active);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interacter>())
        {
            Interacter _i = collision.GetComponent<Interacter>();
            _i.canInteract.Add(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Interacter>())
        {
            Interacter _i = collision.GetComponent<Interacter>();
            _i.canInteract.Remove(gameObject);
        }
    }
}
