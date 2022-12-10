using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLayer : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 7.0f;
    public float jumpVelocity = 14.0f;

    private Rigidbody2D playerRB;

    // Start is called before the first frame update
    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        playerRB.velocity = new Vector2(dirX * moveSpeed, playerRB.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpVelocity);
        }
    }
}