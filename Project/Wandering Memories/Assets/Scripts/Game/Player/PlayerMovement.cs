using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody2D rb;
    private Vector2 movementInput; // Recebe o input do jogador para movimentar
    private Vector2 smoothMovementInput;
    private Vector2 movementInputSmoothVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        setPlayerVelocity();
    }

    private void setPlayerVelocity()
    {
        smoothMovementInput = Vector2.SmoothDamp(smoothMovementInput, movementInput,
            ref movementInputSmoothVelocity, 0.1f); // suavizar o movimento da personagem de jogo

        rb.velocity = smoothMovementInput * speed; // aplicar essa suavização ao movimento da personagem
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    public void VirtualJoystickMove(Vector2 input)
    {
        movementInput = input;
    }
}