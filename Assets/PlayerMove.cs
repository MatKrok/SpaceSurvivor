using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    Vector3 movementVector;
    Transform playerTransform;
    Animator shipFlame;

    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float strafeSpeedFraction = 1f; // 50% of the maximum speed
    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        movementVector = new Vector3();

        shipFlame = playerTransform.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        ShipMovement();
    }

    private void ShipMovement()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (movementVector == Vector3.zero)
        {
            rgbd2d.velocity = Vector3.zero;
        }
        else
        {
            // Calculate the movement speed based on the input direction
            float speed = maxSpeed;
            if (movementVector.x != 0 && movementVector.y != 0) // diagonal movement
            {
                speed *= strafeSpeedFraction;
            }

            movementVector.Normalize();
            movementVector *= speed;

            rgbd2d.velocity = movementVector;

            float angle = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg;

            playerTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


    }


}
