using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvencibilityController : MonoBehaviour
{
    private HealthController healthController;

    private void Start()
    {
        healthController = GetComponent<HealthController>();

        if (PlayerPrefs.GetInt("invulnerable", 0) == 1)
        {
            ToggleCheat(true);
        }
    }

    public void StartInvencibility(float duration)
    {
        if (PlayerPrefs.GetInt("invulnerable", 0) == 0)
        {
            StartCoroutine(InvencibilityCoroutine(duration));
        }
    }

    private IEnumerator InvencibilityCoroutine(float duration)
    {
        healthController.IsInvincible = true;
        yield return new WaitForSeconds(duration);
        healthController.IsInvincible = false;
    }

    public void ToggleCheat(bool value)
    {
        healthController.IsInvincible = value;
    }
}
