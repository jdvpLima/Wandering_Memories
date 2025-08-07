using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image healthBarForeground;

    [SerializeField]
    private AudioClip lowHealthSoundEffect; // Sound effect for low health

    private AudioSource audioSource; // Reference to the AudioSource component
    private Coroutine lowHealthCoroutine; // Reference to the coroutine

    private void Awake()
    {
        // Ensure the AudioSource component exists
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void UpdateHealthBar(HealthController healthController)
    {
        float remainingHealth = healthController.RemainingHealth;

        // Update the health bar
        healthBarForeground.fillAmount = remainingHealth;

        // Handle low-health sound logic
        if (remainingHealth > 0 && remainingHealth <= 0.2f)
        {
            if (lowHealthCoroutine == null) 
            {
                lowHealthCoroutine = StartCoroutine(PlayLowHealthSound());
            }
        }
        else
        {
            StopLowHealthSound(); // Stop the coroutine if health is above 20% or exactly 0
        }
    }

    private IEnumerator PlayLowHealthSound()
    {
        while (true)
        {
            if (lowHealthSoundEffect != null && audioSource != null)
            {
                audioSource.PlayOneShot(lowHealthSoundEffect);
            }

            // Wait for the duration of the sound before playing it again
            yield return new WaitForSeconds(lowHealthSoundEffect.length);
        }
    }

    private void StopLowHealthSound()
    {
        if (lowHealthCoroutine != null)
        {
            StopCoroutine(lowHealthCoroutine);
            lowHealthCoroutine = null;
        }

        if (audioSource.isPlaying)
        {
            audioSource.Stop(); 
        }
    }
}
