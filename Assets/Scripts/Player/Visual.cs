using UnityEngine;

public class Visual : MonoBehaviour
{
    public bool isRight;
    private SpriteRenderer playerSpriteRenderer;
    private Transform weaponTransform;
    private void Start()
    {
        playerSpriteRenderer = transform.GetComponentInParent<SpriteRenderer>();
        weaponTransform = transform.GetChild(0).GetComponent<Transform>();
    }

    private void Update()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(weaponTransform.position);
        weaponTransform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
        if(Input.GetAxisRaw("Horizontal") is not 0)
           isRight = !(Input.GetAxisRaw("Horizontal") >= 0);
        playerSpriteRenderer.flipX = isRight;
    }
}
