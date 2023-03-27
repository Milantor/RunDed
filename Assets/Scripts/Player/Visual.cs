using UnityEngine;

public class Visual : MonoBehaviour
{
    public Player _player;
    public bool isRight;
    private SpriteRenderer playerSpriteRenderer;
    private Transform weaponTransform;
    private SpriteRenderer weaponSprite;
    private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
        playerSpriteRenderer = transform.GetComponentInParent<SpriteRenderer>();
        weaponTransform = transform.GetChild(0).GetComponent<Transform>();
        weaponSprite = weaponTransform.GetComponent<SpriteRenderer>();
    }

    public void ChangeWeaponSprite(Weapon weapon)
    {
        weaponSprite.sprite = weapon.sprite;
    }
    
    private void Update()
    {
        var direction = Input.mousePosition - _camera.WorldToScreenPoint(weaponTransform.position);
        weaponTransform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
        if(Input.GetAxisRaw("Horizontal") is not 0)
           isRight = !(Input.GetAxisRaw("Horizontal") >= 0);
        playerSpriteRenderer.flipX = isRight;
    }
}
