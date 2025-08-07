using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private Transform gunOffset;

    [SerializeField]
    private float timeBetweenShots;

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

            if (timeSinceLastFire >= timeBetweenShots)
            {
                FireBullet();
                lastFireTime = Time.time;
            }
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = bulletSpeed * transform.right;

        GameObject audioObject = new GameObject("Shooting");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        audioSource.clip = soundEffect;
        audioSource.Play();
        if (soundEffect != null)
        {
            Destroy(audioObject, soundEffect.length);
        }
    }
}