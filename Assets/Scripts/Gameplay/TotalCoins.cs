using UnityEngine;

public class TotalCoins : MonoBehaviour
{
    public int CoinsCount => _coinsCount;

    private int _coinsCount;

    private void Awake()
    {
        _coinsCount = transform.childCount;
    }
}
