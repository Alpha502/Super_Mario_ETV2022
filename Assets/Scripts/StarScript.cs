using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{

    public float speed;
    public bool moveLeft;

    private Rigidbody2D rb;
    public int jumpPower = 10;
    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask WhatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, WhatIsGround);

        if (moveLeft)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }

        if (isGrounded)
        {
            Jump();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tube"))
        {
            if (moveLeft)
            {
                moveLeft = false;
            }
            else
            {
                moveLeft = true;
            }
        }

        if (collision.gameObject.tag == "player")
        {
            Destroy(gameObject);
            PlayerController.isStarUp = true;
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpPower;
    }
}
