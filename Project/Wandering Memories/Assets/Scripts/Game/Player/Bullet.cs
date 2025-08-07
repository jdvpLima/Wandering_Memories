using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Enemy"))
        {
            if (collision.CompareTag("Enemy"))
            {
                HealthController healthController = collision.GetComponent<HealthController>();
                healthController.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
