using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public IControllable controllable;

    private void Start()
    {
        controllable = Component.FindAnyObjectByType<Player>();
    }
    void Update()
    {
        if (controllable is null) return;

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01)
            controllable.Move(Input.GetAxisRaw("Horizontal"));

        if (Constants.IsKeyDown("Jump"))
            controllable.Jump();
        if (Constants.IsKeyDown("Dash"))
            controllable.Dash();
    }
}

public interface IControllable
{
    public void Move(float value);
    public void Jump();
    public void Dash(); // Добавить в параметры направление
    public void ForceDash(float direction);
}