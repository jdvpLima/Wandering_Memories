using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystickMove : MonoBehaviour
{
    private FloatingJoystick joystick;
    private PlayerMovement movement;

    // Start is called before the first frame update
    void Start()
    {
        joystick = GetComponent<FloatingJoystick>();
        GameObject player = GameObject.FindWithTag("Player");
        movement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.VirtualJoystickMove(joystick.Direction);
    }
}
