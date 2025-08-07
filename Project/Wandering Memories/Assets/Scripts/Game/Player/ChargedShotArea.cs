using System.Collections.Generic;
using UnityEngine;

public class ChargedShotArea : MonoBehaviour
{
    public float damage = 5f;
    private List<GameObject> affectedEnemies;

    private void Start()
    {
        affectedEnemies = new List<GameObject>();
    }

    private void OnDisable()
    {
        affectedEnemies.Clear();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to an enemy
        if (other.CompareTag("Enemy"))
        {
            if (!affectedEnemies.Contains(other.gameObject))
            {
                affectedEnemies.Add(other.gameObject);
                HealthController healthController = other.GetComponent<HealthController>();
                healthController.TakeDamage(damage);
            }
            
        }
    }
}
