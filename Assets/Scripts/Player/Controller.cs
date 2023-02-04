using UnityEngine;

public class Controller : MonoBehaviour
{
    private IControllable _controllable;

    private void Start()
    {
        _controllable = FindAnyObjectByType<Player>();
    }

    private void Update()
    {
        if (_controllable is null) return;

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.01)
            _controllable.Move(Input.GetAxisRaw("Horizontal"));

        if (Constants.IsKeyDown("Jump"))
            _controllable.Jump();
        if (Constants.IsKeyDown("Dash"))
            _controllable.Dash();
    }
}

public interface IControllable
{
    /// <summary>
    /// Движение по горизонтали
    /// </summary>
    /// <param name="value">Горизонтальная ось<br/>(-1&lt;value&lt;1)</param>
    public void Move(float value);
    /// <summary>
    /// Толчок вверх
    /// </summary>
    public void Jump();
    /// <summary>
    /// Кратковременное ускорение
    /// </summary>
    public void Dash(); // Добавить в параметры направление
    /// <summary>
    /// Рывок в определенном направлении
    /// </summary>
    /// <param name="direction">Направление рывка</param>
    public void ForceDash(float direction);
}