using UnityEngine;

public class EnemySpawnerBothEnemies : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefabBlue;

    [SerializeField]
    private GameObject enemyPrefabKaze;

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
    private bool isBlueEnemyNext = true;

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
        if (isBlueEnemyNext)
        {
            Instantiate(enemyPrefabBlue, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyPrefabKaze, transform.position, Quaternion.identity);
        }

        isBlueEnemyNext = !isBlueEnemyNext; // Toggle between enemy types

        // Notify the GameController about the spawned enemy
        gameController?.RegisterEnemySpawned();

        currentSpawnCount++;
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumTime, maximumTime);
    }
}
