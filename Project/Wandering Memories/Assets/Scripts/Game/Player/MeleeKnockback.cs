using System.Collections.Generic;
using UnityEngine;

public class MeleeKnockback : MonoBehaviour
{
    public float knockbackForce = 3f; // Force of the knockback
    public float damage = 2.5f;
    private List<GameObject> previousAffectedEnemies;
    private List<GameObject> currentAffectedEnemies;

    private void Start()
    {
        previousAffectedEnemies = new List<GameObject>();
        currentAffectedEnemies = new List<GameObject>();
    }

    private void OnDisable()
    {
        //previousAffectedEnemies.RemoveAll(enemy => !currentAffectedEnemies.Contains(enemy)); // reset affected enemies that weren't hit
        currentAffectedEnemies.Clear();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to an enemy
        if (other.CompareTag("Enemy"))
        {
            if (!currentAffectedEnemies.Contains(other.gameObject))
            {
                currentAffectedEnemies.Add(other.gameObject);

                if (!previousAffectedEnemies.Contains(other.gameObject)) // Don't knockback the same enemy twice in row
                { 
                    previousAffectedEnemies.Add(other.gameObject);

                    Rigidbody2D enemyRb = other.GetComponent<Rigidbody2D>();
                    if (enemyRb != null)
                    {
                        // Calculate knockback direction
                        Vector2 knockbackDirection = (other.transform.position - transform.position).normalized;

                        // Apply knockback force
                        enemyRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                    }
                }
                else
                {
                    previousAffectedEnemies.Remove(other.gameObject);
                }

                HealthController healthController = other.GetComponent<HealthController>();
                healthController.TakeDamage(damage);
            }
            
        }
    }
}
