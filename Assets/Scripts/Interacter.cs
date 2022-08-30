using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    public List<GameObject> canInteract;

    private void Start()
    {
        canInteract = new List<GameObject>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract.Count > 0)
        {
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject _go in canInteract)
            {
                Vector3 diff = _go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = _go;
                    distance = curDistance;
                }
            }
            closest.GetComponent<Interact>().interact();
        }
    }
}
