using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    Rigidbody2D rb;
    Vector2 input = new();
    SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        // input.y = Input.GetAxis("Vertical");
        if (input.x < 0)
        {
            sprite.flipX = true;
        } else if (input.x > 0)
        {
            sprite.flipX = false;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = speed * input;
    }

    public float GetInputX()
    {
        return input.x;
    }
}
