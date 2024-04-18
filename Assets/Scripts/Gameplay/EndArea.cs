using UnityEngine;
using UnityEngine.Events;

public class EndArea : MonoBehaviour
{
    public event UnityAction PlayerFinished;

    [SerializeField] private ParticleSystem _finishEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            PlayerFinished?.Invoke();

            _finishEffect.Play();


        }
    }
}
