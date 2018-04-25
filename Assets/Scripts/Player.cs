using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Checkpoint;
    public float MovementSpeed;
    public float JumpVelocity;
    public float DownwardsAcceleration;
    public float FallSpeed;
    public int JumpCount;
    public float JumpGracePeriod;

    private Rigidbody2D rigidBody2D;
    private float horizontalInput;
    private bool grounded;
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
        // Checks if the player is grounded on a platform, also resetting the jumps left.
        if (rigidBody2D.velocity.y == 0 && previousVelocityY == 0 && touchingPlatform)
        {
            jumpsLeft = JumpCount;
            grounded = true;
        }
        else
        {
            if (grounded)
                jumpGraceLeft = JumpGracePeriod;
            grounded = false;
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
        if ((grounded || jumpsLeft < JumpCount) && jumpsLeft > 0)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, JumpVelocity);
            jumpsLeft--;
        }
    }

    public void MoveToCheckpoint()
    {
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
            GameManager.Instance.Restart();
        }

        if(collision.gameObject.tag == "Checkpoint")
        {
            Checkpoint = collision.gameObject;
        }
    }
}
