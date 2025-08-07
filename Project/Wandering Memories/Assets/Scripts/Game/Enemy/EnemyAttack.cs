using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float damageAmount;

    [SerializeField]
    private AudioClip attackSoundEffect; 

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerMovement>())
        {
            var healthController = other.gameObject.GetComponent<HealthController>(); // Vai buscar o componente HealthController
            GameObject tempAudioObject = new GameObject("AttackSoundEffect");
            AudioSource tempAudioSource = tempAudioObject.AddComponent<AudioSource>();

            tempAudioSource.clip = attackSoundEffect;
            tempAudioSource.Play();

            // Destroy the temporary GameObject after the sound finishes playing
            Destroy(tempAudioObject, attackSoundEffect.length);
            healthController.TakeDamage(damageAmount); // Ativa a função de retirar vida ao jogador
        }
    }
    
}
