using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlueScoreAllocator : MonoBehaviour
{
    [SerializeField]
    private int killScore;

    private ScoreController scoreController;

    public void Awake()
    {
        scoreController = FindObjectOfType<ScoreController>();
    }

    public void AllocateScore()
    {
        scoreController.AddScore(killScore);
    }
}
