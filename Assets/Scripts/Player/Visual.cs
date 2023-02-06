using UnityEngine;

public class Visual : MonoBehaviour
{
    public bool isRight;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _spriteRenderer = transform.GetComponentInParent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetAxisRaw("Horizontal") is not 0)
           isRight = !(Input.GetAxisRaw("Horizontal") >= 0);
        _spriteRenderer.flipX = isRight;
    }
}
