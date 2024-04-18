using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SmoothAudioStart : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _targetVolume = 1.0f;
    private float _smooth = 0.001f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.volume = 0f;
    }

    private void Start()
    {
        StartCoroutine(SmoothStart());
    }

    private IEnumerator SmoothStart()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _smooth);

            yield return null;
        }
    }
}
