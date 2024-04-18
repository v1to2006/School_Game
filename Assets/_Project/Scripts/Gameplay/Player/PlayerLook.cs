using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private const string AxisMouseX = "Mouse X";
    private const string AxisMouseY = "Mouse Y";

    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private Player _player;

    private float _rotationLimit = 80f;
    private float _xRotation;

    private void Awake()
    {
        MouseCursor.Hide();
    }

    private void Update()
    {
        Look();
    }

    private void Look()
    {
        float mouseX = Input.GetAxisRaw(AxisMouseX) * _mouseSensitivity;
        float mouseY = Input.GetAxisRaw(AxisMouseY) * _mouseSensitivity;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -_rotationLimit, _rotationLimit);

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _player.transform.Rotate(mouseX * Vector3.up);
    }
}
