using UnityEngine;

public class TotalCoins : MonoBehaviour
{
    public int CoinsCount => _coinsCount;

    [SerializeField] private Transform _coinsContainer;

    private int _coinsCount;

    private void Awake()
    {
        _coinsCount = _coinsContainer.childCount;
    }
}
