using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private float movementSpeed = 25.0f;
    private float horizontalPosition;
    private Vector2 movementDirection;

    void Update()
    {
        horizontalPosition = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        movementDirection = new Vector2(movementSpeed * horizontalPosition, 0);

        rb.velocity = movementDirection;
    }

}
