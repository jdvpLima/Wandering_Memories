using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    public int requiredDefeats = 10; // Number of defeats needed to stop spawning
    private int enemyDefeatCount = 0;

    public EnemySpawnerLevel1 EnemySpawnerLevel1; // Reference to the EnemySpawner

    public void EnemyDefeated()
    {
        enemyDefeatCount++;

        // Stop spawner when the required number of enemies are defeated
        if (enemyDefeatCount >= requiredDefeats && EnemySpawnerLevel1 != null)
        {
            EnemySpawnerLevel1.StopSpawning();
        }
    }
}
