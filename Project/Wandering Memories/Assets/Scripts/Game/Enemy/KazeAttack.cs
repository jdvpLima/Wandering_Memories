using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class KazeAttack : MonoBehaviour
{
    [SerializeField]
    private float damageAmount; // Amount of damage to the player
    [SerializeField]
    private GameObject explosionPrefab; // Explosion prefab to instantiate

    private bool hasExploded = false;

    public AudioClip boom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasExploded)
        {
            hasExploded = true; // Ensure the explosion happens only once
            Explode();

            // Deal damage to the player
            var healthController = collision.gameObject.GetComponent<HealthController>();
            if (healthController != null)
            {
                healthController.TakeDamage(damageAmount);
            }
        }
    }
    private void Explode()
    {
        // Instantiate the explosion prefab
        GameObject explosion = Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        var particleSystem = explosion.GetComponent<ParticleSystem>();
        if (explosionPrefab != null)
        {
            if (particleSystem != null)
            {
                particleSystem.Play();
            }
        }
        else
        {
            Debug.LogError("Explosion prefab is not assigned in the Inspector.");
        }

        GameObject audioObject = new GameObject("TempAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = boom;
        audioSource.Play();
        if (boom != null)
        {
            Destroy(audioObject, boom.length);
        }
        // Destroy the enemy
        Destroy(gameObject);
    }
}