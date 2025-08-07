using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateTowardsMouse : MonoBehaviour
{
    private PlayerShoot playerShoot;

    void Start()
    {
        playerShoot = GetComponent<PlayerShoot>();
    }

    void Update()
    {
        if (Application.platform != RuntimePlatform.Android && PlayerPrefs.GetInt("use_gamepad", 0) == 0)
        {
            // Get the mouse position in world space
            //Vector3 mousePosition = Input.mousePosition; // Mouse position in screen space
            Vector3 mousePosition = Mouse.current.position.ReadValue(); // Mouse position in screen space
            mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z; // Match depth
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Calculate the direction from the player to the mouse
            Vector3 direction = (worldMousePosition - transform.position).normalized;

            // Calculate the angle to rotate
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply the rotation
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void OnLook(InputValue value)
    {
        Vector2 inputVector = value.Get<Vector2>();

        if (inputVector.sqrMagnitude > 0.1f)
        {
            Vector2 direction = new Vector2(inputVector.x, inputVector.y).normalized;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.Rotate(0, 0, 90);
        }

    }

    public void VirtualJoystickAim(Vector2 input)
    {
        if (input.sqrMagnitude > 0.1f)
        {
            Vector2 direction = new Vector2(input.x, input.y).normalized;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.Rotate(0, 0, 90);
        }

        if (input.sqrMagnitude > 0f)
        {
            playerShoot.firing = true;
        }
        else
        {
            playerShoot.firing = false;
        }
    }
}
