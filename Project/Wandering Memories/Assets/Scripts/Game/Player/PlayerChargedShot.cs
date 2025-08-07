using System;
using System.Collections;
using UnityEngine;

public class PlayerChargedShot : MonoBehaviour
{
    public GameObject attackArea; // The circle GameObject (with Collider)
    public float shotDuration = 0.3f; // Duration the attack is active
    public float chargeTime = 1.5f;
    [System.NonSerialized]
    public float beganChargingTime;
    [System.NonSerialized]
    public bool firing;

    [SerializeField]
    private AudioClip chargedShotSoundEffect;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            beganChargingTime = Time.time;
            chargeTime = 3f;
        }   
    }

    void Update()
    {
        if (firing || Application.platform == RuntimePlatform.Android)
        {
            float timeSinceStartedCharging = Time.time - beganChargingTime;

            if (timeSinceStartedCharging >= chargeTime)
            {
                StartCoroutine(PerformChargedShot());
                beganChargingTime = Time.time;
            }
        }
    }

    private IEnumerator PerformChargedShot()
    {
        if (chargedShotSoundEffect != null)
        {
            GameObject audioObject = new GameObject("ChargedShotSound");
            AudioSource audioSource = audioObject.AddComponent<AudioSource>();
            audioSource.clip = chargedShotSoundEffect;
            audioSource.Play();
            Destroy(audioObject, chargedShotSoundEffect.length); // Destroy after the sound finishes
        }
        attackArea.SetActive(true); // Enable the attack circle
        yield return new WaitForSeconds(shotDuration); // Wait for the shot duration
        attackArea.SetActive(false); // Disable the attack circle
    }
}