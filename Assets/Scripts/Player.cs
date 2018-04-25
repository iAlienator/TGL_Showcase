using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int DeathCount { get; private set; }
    public bool IsDead { get; private set; }
    public GameObject Checkpoint;
    public float MovementSpeed;
    public float JumpVelocity;
    public float DownwardsAcceleration;
    public float FallSpeed;
    public int JumpCount;
    public float JumpGracePeriod;

    private Rigidbody2D rigidBody2D;
    private float horizontalInput;
    private bool isGrounded;
    private bool touchingPlatform;
    private float previousVelocityY;
    private int jumpsLeft;
    private float jumpGraceLeft;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (Checkpoint != null)
            MoveToCheckpoint();

        jumpsLeft = JumpCount;
    }

    void Update()
    {
        // Checks if the player is grounded and on a platform
        if (rigidBody2D.velocity.y == 0 && previousVelocityY == 0 && touchingPlatform)
        {
            isGrounded = true;
            jumpsLeft = JumpCount;
            jumpGraceLeft = JumpGracePeriod;
        }
        // Else if player is deemed falling.
        else
        {
            // Decrement the delta time from jump grace timer.
            if (jumpGraceLeft > 0)
                jumpGraceLeft -= Time.deltaTime;

            isGrounded = false;
        }

        // Accelerate downwards momentum.
        if (rigidBody2D.velocity.y < 0)
            rigidBody2D.velocity -= new Vector2(0, DownwardsAcceleration);

        // Limit the maxium falling speed.
        if (rigidBody2D.velocity.y < FallSpeed)
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, FallSpeed);

        // Horizontal movement based on the horizontal input value and movement speed.
        rigidBody2D.velocity = new Vector2(horizontalInput * MovementSpeed, rigidBody2D.velocity.y);

        previousVelocityY = rigidBody2D.velocity.y;
    }

    public void Jump()
    {
        // Allow jumping if player is grounded, or if player has already jumped once and has jumps left.
        if ((isGrounded || jumpsLeft < JumpCount || jumpGraceLeft > 0) && jumpsLeft > 0)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, JumpVelocity);
            jumpsLeft--;
        }
    }

    public void MoveToCheckpoint()
    {
        IsDead = false;
        GetComponent<Player>().enabled = true;
        transform.position = new Vector3(Checkpoint.transform.position.x, Checkpoint.transform.position.y, transform.position.z);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lethal")
        {
            DeathCount++;
            IsDead = true;
            GetComponent<Player>().enabled = false;
        }

        if(collision.gameObject.tag == "Checkpoint")
        {
            var checkpointController = collision.gameObject.GetComponent<CheckpointController>();
            if (!checkpointController.IsCurrent)
            {
                checkpointController.SetAsCurrentCheckpoint();
                Checkpoint = collision.gameObject;
            }
        }
    }
}
