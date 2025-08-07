using System;
using System.Collections;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public GameObject meleeArea; // The rectangle GameObject (with BoxCollider2D)
    public float meleeDuration = 0.2f; // Duration the melee attack is active
    public float cooldown = 0.75f;

    [SerializeField]
    private AudioClip soundEffect;

    [System.NonSerialized]
    public bool firing;
    private float lastFireTime;

    void Update()
    {
        if (firing)
        {
            float timeSinceLastFire = Time.time - lastFireTime;

            if (timeSinceLastFire >= cooldown)
            {
                StartCoroutine(PerformMelee());
                lastFireTime = Time.time;
            }
        }
    }

    public void autofire()
    {
        float timeSinceLastFire = Time.time - lastFireTime;

        if (timeSinceLastFire >= cooldown)
        {
            StartCoroutine(PerformMelee());
            lastFireTime = Time.time;
        }
    }

    private IEnumerator PerformMelee()
    {
        // Create and play the sound effect at the start of the melee attack
        if (soundEffect != null)
        {
            GameObject audioObject = new GameObject("Swing");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = soundEffect;
            audioSource.Play();
            Destroy(audioObject, soundEffect.length); 
        }

        // Enable the melee area
        meleeArea.SetActive(true);

        // Wait for the melee duration
        yield return new WaitForSeconds(meleeDuration);

        // Disable the melee area
        meleeArea.SetActive(false);
    }

}