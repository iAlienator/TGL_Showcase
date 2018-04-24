using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public int JumpCount;
    public float JumpVelocity;
    public float JumpDownAcceleration;
    public Transform[] GroundCheck;

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

        // Creates 2 linecasts from the center of the player to the points to check for ground tiles.
        //Vector2 offset0 = new Vector3(transform.position.x - GroundCheck[0].position.x, transform.position.y);
        //Vector2 offset1 = new Vector3(transform.position.x - GroundCheck[1].position.x, transform.position.y);
        //if (Physics2D.Linecast(transform.position, GroundCheck[0].position, 1 << LayerMask.NameToLayer("Ground")) ||
        //    Physics2D.Linecast(transform.position, GroundCheck[1].position, 1 << LayerMask.NameToLayer("Ground")))
        //{
        //    if (!isGrounded)
        //    {
        //        isGrounded = true;
        //        jumpsLeft = JumpCount;
        //    }
        //}
        //else
        //{
        //    isGrounded = false;
        //}

        // Jump if possible.
        if (Input.GetKeyDown("space") && jumpsLeft > 0)
            Jump();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal * rigidBody2D.velocity.x < MovementSpeed)
            rigidBody2D.AddForce(Vector2.right * horizontal * 300f);

        if (Mathf.Abs(rigidBody2D.velocity.x) > MovementSpeed)
            rigidBody2D.velocity = new Vector2(Mathf.Sign(rigidBody2D.velocity.x) * MovementSpeed, rigidBody2D.velocity.y);

        // Accelerates the jump when moving down.
        //if (rigidBody2D.velocity.y < 0)
        //    rigidBody2D.velocity += new Vector2(rigidBody2D.velocity.x, Physics2D.gravity.y * JumpDownAcceleration);
    }

    private void Jump()
    {
        rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, 0);
        rigidBody2D.AddForce(Vector2.up * JumpVelocity, ForceMode2D.Impulse);

        jumpsLeft--;
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    //isGrounded = true;

    //    if (!isGrounded && collision.gameObject.tag == "Ground")
    //    {
    //        isGrounded = true;
    //        //Debug.Log(isGrounded);
    //    }
    //    //    if (collision.gameObject.tag == "Ground")
    //    //    {
    //    //        var groudPos = collision.gameObject.transform.position;
    //    //        Debug.Log(groudPos);
    //    //        //if (groudPos.y <= GroundCheck.position.y + 0.5f)
    //    //        //    Debug.Log("LUL");
    //    //    }
    //}
}
