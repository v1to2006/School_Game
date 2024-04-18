using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityAction PauseButtonPressed;

    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerLook _look;
    [SerializeField] private KeyCode _pauseButton;

    private bool _playerInputEnabled = true;

    private void Update()
    {
        if (Input.GetKeyDown(_pauseButton))
            PauseButtonPressed?.Invoke();
    }

    private void OnEnable()
    {
        PauseButtonPressed += SwitchPlayerInputState;
    }

    private void OnDisable()
    {
        PauseButtonPressed -= SwitchPlayerInputState;
    }

    public void EnablePlayerInput()
    {
        _movement.enabled = true;
        _look.enabled = true;

        _playerInputEnabled = true;
    }

    public void DisablePlayerInput()
    {
        _movement.enabled = false;
        _look.enabled = false;

        _playerInputEnabled = false;
    }

    private void SwitchPlayerInputState()
    {
        if (_playerInputEnabled)
        {
            DisablePlayerInput();
        }
        else
        {
            EnablePlayerInput();
        }
    }
}
