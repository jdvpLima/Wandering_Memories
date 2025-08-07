using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public UnityEvent ScoreChange;
    public int Score { get; private set; }
    public void AddScore(int amount)
    {
        Score += amount;
        ScoreChange.Invoke();
    }
}
