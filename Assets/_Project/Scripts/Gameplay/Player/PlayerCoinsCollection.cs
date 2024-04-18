using UnityEngine;

public class PlayerCoinsCollection : MonoBehaviour
{
    public int CoinsCollected => _coinsCollected;

    [SerializeField] private Coin _coin;

    private int _coinsCollected;

    private void OnEnable()
    {
        _coin.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _coin.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        _coinsCollected++;
    }
}
