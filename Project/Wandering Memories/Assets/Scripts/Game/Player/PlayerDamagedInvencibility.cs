using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamagedInvencibility : MonoBehaviour
{
    [SerializeField]
    private float duration;

    private InvencibilityController invencibilityController;

    private void Awake()
    {
        invencibilityController = GetComponent<InvencibilityController>();
    }

    public void StartInvincibility()
    {
        invencibilityController.StartInvencibility(duration);
    }
}
