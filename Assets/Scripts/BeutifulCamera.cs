using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeutifulCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private new Camera camera;
    public float speed, xOffset, yOffset, zOffset;
    public bool Aim, oldAim;
    Projectile Projectile;

    private void Start()
    {
        camera = Camera.main;
        Projectile = GameObject.FindObjectOfType<Projectile>();
    }
    void Update()
    {
        float x, y, z;
        if (Aim == false)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 48, speed + Time.deltaTime);
        }
        else
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 48 / 1.5f, speed + Time.deltaTime);
        }
        oldAim = Aim;
        if (Aim == false)
        {
            x = Mathf.Lerp(camera.transform.position.x, player.transform.position.x + xOffset, speed + Time.deltaTime);
            y = Mathf.Lerp(camera.transform.position.y, player.transform.position.y + yOffset, speed + Time.deltaTime);
            z = Mathf.Lerp(camera.transform.position.z, player.transform.position.z + zOffset, speed + Time.deltaTime);

        }
        else
        {
            x = Mathf.Lerp(camera.transform.position.x, Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, player.transform.position.x - 65, player.transform.position.x + 65), speed/1.5f + Time.deltaTime);
            y = Mathf.Lerp(camera.transform.position.y, Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, player.transform.position.y - 65, player.transform.position.y + 65), speed/1.5f + Time.deltaTime);
            z = Mathf.Lerp(camera.transform.position.z, player.transform.position.z + zOffset, speed + Time.deltaTime);
        }
        camera.transform.position = new Vector3(x, y, z);
    }
}