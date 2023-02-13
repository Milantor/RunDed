using UnityEngine;

public class BeutifulCamera : MonoBehaviour
{
    private Transform player, cameraTransform;
    [SerializeField] private float cameraSize;
    private new Camera camera;
    public float speed, xOffset, yOffset, zOffset;

    private void Start()
    {
        player = FindAnyObjectByType<Player>().transform;
        camera = Camera.main;
        cameraTransform = camera.transform;
        cameraSize = (cameraSize == 0) ? 3 : cameraSize;
    }

    private void Update()
    {
        var position = cameraTransform.position;
        var position1 = player.position;
        var x = Mathf.Lerp(position.x, position1.x + xOffset, speed + Time.deltaTime);
        var y = Mathf.Lerp(position.y, position1.y + yOffset, speed + Time.deltaTime);
        position = new Vector3(x, y, zOffset);
        cameraTransform.position = position;
    }
}