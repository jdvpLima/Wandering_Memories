using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefbabBlue;

    [SerializeField]
    private GameObject enemyPrefbabKaze;

    [SerializeField]
    private float minimumTime;

    [SerializeField]
    private float maximumTime;

    private float timeUntilSpawn;
    private bool isBlueEnemyNext = true;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            if (isBlueEnemyNext)
            {
                Instantiate(enemyPrefbabBlue, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(enemyPrefbabKaze, transform.position, Quaternion.identity);
            }

            isBlueEnemyNext = !isBlueEnemyNext; // Toggle between enemy types
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumTime, maximumTime);
    }
}