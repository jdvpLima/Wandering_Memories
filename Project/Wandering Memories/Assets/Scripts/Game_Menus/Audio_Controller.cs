using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Controller : MonoBehaviour
{
    [SerializeField] private AudioClip rolloverSound;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip returnSound;
    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure there's an AudioSource on the GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayRolloverSound()
    {
        if (rolloverSound != null)
        {
            audioSource.PlayOneShot(rolloverSound);
        }
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    public void PlayReturnSound()
    {
        if (returnSound != null)
        {
            audioSource.PlayOneShot(returnSound);
        }
    }
}
