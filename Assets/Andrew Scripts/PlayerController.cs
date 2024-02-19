using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpDuration;
    [SerializeField] float jumpHeight;
    [SerializeField] bool isGrounded;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
        HorizontalMove();
    }

    void Jump()
    {
        float g = -2 * jumpHeight / (jumpDuration * jumpDuration);

        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            g *= 2;
        }

        float v = -g * jumpDuration;

        Physics2D.gravity = new Vector2(0, g);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * v;
            isGrounded = false;
        }
    }

    void HorizontalMove()
    {
        moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
