using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Menu : MonoBehaviour
{
    [SerializeField]
    private Toggle gamepadToggle;
    [SerializeField]
    private Toggle invulnerabilityToggle;
    private GameObject player;
    InvencibilityController invencibilityController;

    // Start is called before the first frame update
    void Start()
    {
        int useGamepad = PlayerPrefs.GetInt("use_gamepad", 0);
        gamepadToggle.isOn = useGamepad == 1;
        int invulnerable = PlayerPrefs.GetInt("invulnerable", 0);
        invulnerabilityToggle.isOn = invulnerable == 1;
        player = GameObject.FindWithTag("Player");
        if (player != null )
        {
            invencibilityController = player.GetComponent<InvencibilityController>();
        }
    }

    public void ToggleUseGamepad()
    {
        bool value = gamepadToggle.isOn;
        PlayerPrefs.SetInt("use_gamepad", value ? 1 : 0);
    }

    public void ToggleInvulnerability()
    {
        bool value = invulnerabilityToggle.isOn;
        PlayerPrefs.SetInt("invulnerable", value ? 1 : 0);
        if (invencibilityController != null)
        {
            invencibilityController.ToggleCheat(value);
        }
    }
}
