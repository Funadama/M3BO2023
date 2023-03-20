using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public LayerMask obstacleLayer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input from arrow keys or WASD
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement.Normalize();

        // Cast a ray to check for obstacles
        RaycastHit hit;
        if (Physics.Raycast(transform.position, movement, out hit, 0.6f, obstacleLayer))
        {
            // Do not move if there is an obstacle
            movement = Vector3.zero;
        }

        // Move the player
        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
    }
}
