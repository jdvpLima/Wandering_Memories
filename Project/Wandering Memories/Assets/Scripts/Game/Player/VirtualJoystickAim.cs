using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualJoystickAim : MonoBehaviour
{
    private FloatingJoystick joystick;
    private RotateTowardsMouse rotate;

    // Start is called before the first frame update
    void Start()
    {
        joystick = GetComponent<FloatingJoystick>();
        GameObject player = GameObject.FindWithTag("Player");
        rotate = player.GetComponent<RotateTowardsMouse>();
    }

    // Update is called once per frame
    void Update()
    {
        rotate.VirtualJoystickAim(joystick.Direction);
    }
}
