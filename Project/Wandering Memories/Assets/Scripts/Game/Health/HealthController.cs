using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;

    [SerializeField]
    private float maximumHealth;

    [SerializeField]
    private AudioClip hitSoundEffect; // Sound effect for when damaged
    [SerializeField]
    private AudioClip deathSoundEffect; // Sound effect for when health reaches zero

    private AudioSource audioSource; // Reference to the AudioSource component

    public bool IsInvincible { get; set; } // Periodo de invencibilidade

    public UnityEvent OnDeath; // Quando o jogador ou inimigo morra
    public UnityEvent OnDamaged; // Invocamos este evento sempre que o jogador ou o inimigo sofra dano
    public UnityEvent OnHealthChanged; // Invocamos isto sempre que haja alteração na vida do Jogador


    public float RemainingHealth
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }

    private void Awake()
    {
        // Ensure the AudioSource component exists
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void TakeDamage(float damage)
    {
        if (currentHealth == 0) { return; }
        if (IsInvincible) { return; }

        currentHealth -= damage;

        if (currentHealth > 0)
        {
            PlayHitSound();
        }

        OnHealthChanged.Invoke(); // Invocamos isto sempre que haja alteração na vida do jogador
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if (currentHealth == 0)
        {

            OnDeath.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float AddHealthAmount)
    {
        if (currentHealth == maximumHealth) { return; } // Salta esta função á frente se a vida tiver no máximo
        currentHealth += AddHealthAmount;
        OnHealthChanged.Invoke(); // Invocamos o método para caso o jogador perca vida
        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth; // Para não haver excesso quando o jogador recupera vida
        }
    }

    public void Destroy()
    {
        if (deathSoundEffect != null)
        {
            GameObject tempAudioObject = new GameObject("DeathSoundEffect");
            AudioSource tempAudioSource = tempAudioObject.AddComponent<AudioSource>();

            tempAudioSource.clip = deathSoundEffect;
            tempAudioSource.Play();
            Destroy(tempAudioObject, deathSoundEffect.length);
        }

        if (GameController.Instance != null)
        {
            GameController.Instance.RegisterEnemyDefeated();
        }

        // Destroy the original GameObject immediately
        Destroy(gameObject);
    }

    private void PlayHitSound()
    {
        if (hitSoundEffect != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitSoundEffect);
        }
    }
}
