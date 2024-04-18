using System.Collections;
using UnityEngine;

public class PlayerFinishedState : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private PlayerLook _playerLook;
    [SerializeField] private Animator _cameraAnimator;
    [SerializeField] private Transform _inGameUI;
    [SerializeField] private Transform _finalScoreView;
    [SerializeField] private EndArea _endArea;
    [SerializeField] Transform _finishedPoint;

    private float _smoothMove = 800f;
    private Vector3 _inputVelocity;

    private void OnEnable()
    {
        _endArea.PlayerFinished += StartMove;
    }

    private void OnDisable()
    {
        _endArea.PlayerFinished -= StartMove;
    }

    private void StartMove()
    {
        _playerCamera.transform.parent = null;
        _playerLook.enabled = false;
        _inGameUI.gameObject.SetActive(false);
        _cameraAnimator.enabled = true;
        _finalScoreView.gameObject.SetActive(true);
        MouseCursor.Show();

        _player.gameObject.SetActive(false);

        StartCoroutine(MovePlayerToFinishedPosition());
    }

    public IEnumerator MovePlayerToFinishedPosition()
    {
        while (true)
        {
            _playerCamera.transform.position = Vector3.SmoothDamp(_playerCamera.transform.position, _finishedPoint.position, ref _inputVelocity, _smoothMove * Time.deltaTime);

            yield return null;
        }
    }
}
