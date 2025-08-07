using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMelee : MonoBehaviour
{
    [SerializeField]
    private PlayerMelee melee;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to an enemy
        if (other.CompareTag("Enemy"))
        {
            melee.autofire();
        }
    }
}
