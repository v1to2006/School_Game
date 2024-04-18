using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Coin : MonoBehaviour
{
    public UnityAction CoinCollected;

    [SerializeField] private ParticleSystem _destroyEffect;
    [SerializeField] private Transform _body;

    private BoxCollider _collider;

    private float _destroyDelayTime = 1f;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            Collect();
        }
    }

    private void Collect()
    {
        CoinCollected?.Invoke();

        _destroyEffect.Play();

        _collider.enabled = false;
        _body.gameObject.SetActive(false);

        StartCoroutine(DisableWithDelay());
    }

    private IEnumerator DisableWithDelay()
    {
        WaitForSeconds destroyDelay = new(_destroyDelayTime);

        yield return destroyDelay;

        gameObject.SetActive(false);
    }
}
