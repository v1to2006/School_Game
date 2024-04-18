using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private EndArea _endArea;
    [SerializeField] private Timer _timer;
    [SerializeField] private PlayerCoins _playerCoins;
    [SerializeField] private TotalCoins _totalCoins;

    [SerializeField] private TextMeshProUGUI _finalScoreView;
    [SerializeField] private TextMeshProUGUI _coinsView;
    [SerializeField] private TextMeshProUGUI _timeView;

    private void OnEnable()
    {
        _endArea.PlayerFinished += DisplayScores;
    }

    private void OnDisable()
    {
        _endArea.PlayerFinished -= DisplayScores;
    }

    private void DisplayScores()
    {
        _finalScoreView.text = $"Total Score\n{GetFinalScore()}";
        _coinsView.text = $"Coins\n{_playerCoins.CoinsCollected}/{_totalCoins.CoinsCount}";
        _timeView.text = $"Time\n{_timer.FinishedTime:0.0}";
    }

    private int GetFinalScore()
    {
        const int CoinValue = 10;
        const int TimeValue = 5;
        const int MaxTimeBonus = 100;

        int coinScore = _playerCoins.CoinsCollected * CoinValue;

        int timeBonus = MaxTimeBonus - (int)_timer.FinishedTime * TimeValue;
        timeBonus = Math.Max(timeBonus, 0);

        int totalScore = coinScore + timeBonus;

        return totalScore;
    }
}
