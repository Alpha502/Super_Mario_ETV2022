using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Transform player;

    public int jumpPower = 5;
    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask WhatIsGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (player.localScale.x < 0)
            speed = -speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, WhatIsGround);

        if (isGrounded)
        {
            rb.velocity = Vector2.up * jumpPower;
        }
    }
}
