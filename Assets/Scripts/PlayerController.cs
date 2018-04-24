using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int JumpCount;

    private Rigidbody2D rigidBody2D;
    private bool isGrounded;
    private int jumpsLeft;

	void Start ()
    {
        jumpsLeft = JumpCount;

        Debug.Log("Hello", gameObject);
        rigidBody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        if (Input.GetAxis("Horizontal") != 0)
            transform.position += new Vector3(Input.GetAxis("Horizontal") * 0.2f, 0);
        if (Input.GetAxis("Vertical") != 0)
            transform.position += new Vector3(0, Input.GetAxis("Vertical") * 0.2f);

        if (Input.GetKeyDown("space") && isGrounded)
            rigidBody2D.velocity = new Vector2(0, 10);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrounded)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isGrounded)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = false;
            }
        }
    }
}
