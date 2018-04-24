using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public int JumpCount;
    public float JumpHeight;
    public float JumpDownAcceleration;
    public Transform GroundCheck;

    private Rigidbody2D rigidBody2D;
    private bool isGrounded;
    private int jumpsLeft;

	void Start ()
    {
        jumpsLeft = JumpCount;

        rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        isGrounded = Physics2D.Linecast(transform.position, GroundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKeyDown("space") && (jumpsLeft > 0 || isGrounded))
            Jump();

        //if (Input.GetAxis("Horizontal") != 0)
        //    rigidBody2D.AddForce(Vector2.right * Input.GetAxis("Horizontal"), ForceMode2D.Impulse);

        //if (Input.GetKeyDown("space") && jumpsLeft > 0)
        //    Jump();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal * rigidBody2D.velocity.x < MovementSpeed)
            rigidBody2D.AddForce(Vector2.right * horizontal * 1000f);

        if (Mathf.Abs(rigidBody2D.velocity.x) > MovementSpeed)
            rigidBody2D.velocity = new Vector2(Mathf.Sign(rigidBody2D.velocity.x) * 5f, rigidBody2D.velocity.y);

        if (rigidBody2D.velocity.y < 0)
            rigidBody2D.velocity += (Vector2.up * Physics2D.gravity.y) * JumpDownAcceleration;

        //if (Input.GetAxis("Horizontal") != 0)
        //    rigidBody2D.AddForce(Vector2.right * Input.GetAxis("Horizontal"), ForceMode2D.Impulse);
        //if (Input.GetAxis("Vertical") != 0)
        //    transform.position += new Vector3(0, Input.GetAxis("Vertical") * 0.2f);

        //if (Input.GetKeyDown("space") && jumpsLeft > 0)
        //    Jump();
    }

    private void Jump()
    {
        //Debug.Log(isGrounded);

        if (isGrounded)
            jumpsLeft = JumpCount;

        rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, 0);
        rigidBody2D.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
        //rigidBody2D.velocity = new Vector2(0, JumpHeight);
        jumpsLeft--;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!isGrounded)
    //    {
    //        if (collision.gameObject.tag == "Ground")
    //        {
    //            isGrounded = true;
    //            jumpsLeft = JumpCount;
    //        }
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (isGrounded)
    //    {
    //        if (collision.gameObject.tag == "Ground")
    //        {
    //            isGrounded = false;
    //        }
    //    }
    //}
}
