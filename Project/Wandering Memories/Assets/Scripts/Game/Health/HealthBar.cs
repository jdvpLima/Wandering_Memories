using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private HealthController healthController;

    [SerializeField]
    private Transform bar;

    public void UpdateBar()
    {
        float percentage = healthController.RemainingHealth;
        bar.localScale = new Vector2(percentage, bar.localScale.y);
        bar.localPosition = new Vector2(-(1 - percentage) / 2, bar.localPosition.y);
    }
}
