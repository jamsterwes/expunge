using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
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

        playerRB.velocity = new Vector2(dirX*7f, playerRB.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 14f);
        }
    }
}