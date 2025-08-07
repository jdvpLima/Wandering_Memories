using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; } // Verifica se o inimigo notou o jogador

    public Vector2 DirectionToPlayer { get; private set; } // Inimigo saber onde o jogador está

    [SerializeField]
    private float playerAwarenessDistance; // Valor para alterarmos a distancia que ele deteta o jogador

    private Transform player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform; // Podemos usar isto para depois usarmos nos objetos para Capture The Flag
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayer = player.position - transform.position;
        DirectionToPlayer = enemyToPlayer.normalized;

        // Neste caso o movimento está para o player porque isto vai ser usado para endless mode e para os niveis de combate

        if (enemyToPlayer.magnitude <= playerAwarenessDistance)
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
    }
}
