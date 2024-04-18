using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float FinishedTime => _time;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private TextMeshProUGUI _timeView;
    [SerializeField] private EndArea _endArea;

    private float _time = 0f;
    private bool _timerPaused = false;

    private Coroutine _timerCoroutine;

    private void Awake()
    {
        StartTimer();
    }

    private void OnEnable()
    {
        _endArea.PlayerFinished += StopTimer;
        _playerInput.PauseButtonPressed += SwitchTimerState;
    }

    private void OnDisable()
    {
        _endArea.PlayerFinished -= StopTimer;
        _playerInput.PauseButtonPressed -= SwitchTimerState;
    }

    private void SwitchTimerState()
    {
        if (_timerPaused)
        {
            ContinueTimer();
        }
        else
        {
            PauseTimer();
        }
    }

    private void StartTimer()
    {
        _timerCoroutine = StartCoroutine(Count());
    }

    private void StopTimer()
    {
        StopCoroutine(_timerCoroutine);
    }

    private void ContinueTimer()
    {
        _timerPaused = false;
    }

    private void PauseTimer()
    {
        _timerPaused = true;
    }

    private void UpdateTimerView()
    {
        _timeView.text = _time.ToString("0.0");
    }

    private IEnumerator Count()
    {
        while (true)
        {
            if (_timerPaused == false)
            {
                _time += Time.deltaTime;

                UpdateTimerView();
            }

            yield return null;
        }
    }
}
