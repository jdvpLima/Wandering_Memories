using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    [SerializeField] private SpecialObject specialObject; // Reference to the SpecialObject
    [SerializeField] private GameObject[] spawners; // Array of all spawners in the scene

    private int stoppedSpawners = 0;
    private int totalEnemies = 0; // Total enemies spawned
    private int defeatedEnemies = 0; // Total enemies defeated

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NotifySpawnerStopped()
    {
        stoppedSpawners++;

        // Check if all spawners have stopped
        CheckConditions();
    }

    public void RegisterEnemySpawned()
    {
        totalEnemies++;
    }

    public void RegisterEnemyDefeated()
    {
        defeatedEnemies++;

        // Check if all enemies are defeated
        CheckConditions();
    }

    private void CheckConditions()
    {
        // Activate the SpecialObject only when all spawners have stopped or all enemies are defeated
        if (stoppedSpawners >= spawners.Length || defeatedEnemies >= totalEnemies)
        {
            ActivateSpecialObject();
        }
    }

    private void ActivateSpecialObject()
    {
        if (specialObject != null)
        {
            specialObject.ActivateSpecialObject();
        }
        else
        {
            Debug.LogError("SpecialObject is not assigned in the GameController!");
        }
    }
}
