using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private bool grounded;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal * rigidBody2D.velocity.x < 5f)
            rigidBody2D.AddForce(Vector2.right * horizontal * 300f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!grounded && collision.gameObject.tag == "Platform")
        {
            grounded = true;
            Debug.Log("123");
        } //grounded = false;
    }
}
