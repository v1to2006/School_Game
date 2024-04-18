using UnityEngine;

public class UserInterfaceViewHandler : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private Transform _inGameUI;

    private void Awake()
    {
        HidePauseMenu();
    }

    private void OnEnable()
    {
        _playerInput.PauseButtonPressed += SwitchUIState;
    }

    private void OnDisable()
    {
        _playerInput.PauseButtonPressed -= SwitchUIState;
    }

    private void SwitchUIState()
    {
        if (_pauseMenu.isActiveAndEnabled)
        {
            HidePauseMenu();
        }
        else
        {
            ShowPauseMenu();
        }
    }

    private void ShowPauseMenu()
    {
        MouseCursor.Show();

        _pauseMenu.gameObject.SetActive(true);
        _inGameUI.gameObject.SetActive(false);
    }

    private void HidePauseMenu()
    {
        MouseCursor.Hide();

        _pauseMenu.gameObject.SetActive(false);
        _inGameUI.gameObject.SetActive(true);
    }
}
