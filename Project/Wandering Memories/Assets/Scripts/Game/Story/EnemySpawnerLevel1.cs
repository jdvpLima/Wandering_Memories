using UnityEngine;

public class EnemySpawnerLevel1 : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefabBlue;

    [SerializeField]
    private float minimumTime;

    [SerializeField]
    private float maximumTime;

    [SerializeField]
    private int maxSpawnCount = 10;

    private float timeUntilSpawn;
    private int currentSpawnCount = 0;

    private bool stopSpawning = false;
    private bool hasNotified = false; // Ensures notification is sent only once

    public GameController gameController; // Reference to the GameController

    public void StopSpawning()
    {
        stopSpawning = true;

        if (!hasNotified && gameController != null)
        {
            gameController.NotifySpawnerStopped();
            hasNotified = true;
        }
    }

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        if (stopSpawning || currentSpawnCount >= maxSpawnCount)
        {
            StopSpawning(); // Ensure StopSpawning is called when spawner stops
            return;
        }

        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            SpawnEnemy();
            SetTimeUntilSpawn();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefabBlue, transform.position, Quaternion.identity);

        // Notify the GameController about the spawned enemy
        gameController?.RegisterEnemySpawned();

        currentSpawnCount++;
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumTime, maximumTime);
    }
}
