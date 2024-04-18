using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    public void Continue()
    {
        _playerInput.PauseButtonPressed?.Invoke();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
