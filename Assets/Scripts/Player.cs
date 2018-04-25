using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed;
    public float JumpVelocity;
    public float DownwardsAcceleration;
    public int JumpCount;

    private Rigidbody2D rigidBody2D;
    private float horizontalInput;
    private bool grounded;
    private bool touchingPlatform;
    private float previousVelocityY;
    private int jumpsLeft;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        jumpsLeft = JumpCount;
    }

    void Update()
    {
        // Checks if the player is grounded on a platform, also resetting the jumps left.
        if (rigidBody2D.velocity.y == 0 && previousVelocityY == 0 && touchingPlatform)
        {
            jumpsLeft = JumpCount;
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        // Accelerate downwards momentum.
        if (rigidBody2D.velocity.y < 0)
            rigidBody2D.velocity -= new Vector2(0, DownwardsAcceleration);

        // Horizontal movement based on the horizontal input value and movement speed.
        rigidBody2D.velocity = new Vector2(horizontalInput * MovementSpeed, rigidBody2D.velocity.y);

        previousVelocityY = rigidBody2D.velocity.y;
    }

    public void Jump()
    {
        // Allow jumping if player is grounded, or if player has already jumped once and has jumps left.
        if ((grounded || jumpsLeft < JumpCount) && jumpsLeft > 0)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, JumpVelocity);
            jumpsLeft--;
        }
    }

    public void SetHorizontalInput(float value)
    {
        horizontalInput = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = false;
        }
    }
}
