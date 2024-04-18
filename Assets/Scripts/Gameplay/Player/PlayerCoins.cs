using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public int CoinsCollected => _coinsCollected;

    [SerializeField] private Coin _coin;

    private int _coinsCollected;

    private void OnEnable()
    {
        Coin.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        Coin.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        _coinsCollected++;
    }
}
