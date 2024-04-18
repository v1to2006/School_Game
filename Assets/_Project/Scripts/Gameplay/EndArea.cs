using UnityEngine;
using UnityEngine.Events;

public class EndArea : MonoBehaviour
{
    public UnityAction PlayerFinished;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            PlayerFinished?.Invoke();
        }
    }
}
