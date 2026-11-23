using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    float normalSpeed;
    float stealthSpeed;
    [SerializeField] GroundManager ground;
    Rigidbody2D rb;
    Vector2 input = new();
    Vector2 appliedForce = new(); // kinda Force2D.Impulse
    float horizontalAxis;
    // readonly float AirFactor = 3f;
    readonly float ForceError = 0.5f;
    SpriteRenderer sprite;
    bool jump;
    bool tryJump;
    bool stealth;
    [SerializeField] float maxJumpBuffer = 0.15f;
    float jumpBufferElapsed;
    [SerializeField] float initialJumpSpeed = 5f;
    [SerializeField] float gravity = -0.3f;
    [SerializeField] float maxGravity = -2.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        normalSpeed = speed;
        stealthSpeed = speed / 2f;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        jump = false;
        tryJump = false;
        stealth = false;
        horizontalAxis = 0f;
        jumpBufferElapsed = maxJumpBuffer;
        // Application.targetFrameRate = -1;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        if (jumpBufferElapsed < maxJumpBuffer)
        {
            jumpBufferElapsed += Time.deltaTime;
        }
        if (/*Input.GetKeyDown(KeyCode.W) ||*/ Input.GetKeyDown(KeyCode.Space))
        {
            tryJump = true;
            jumpBufferElapsed = 0f;
        }
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
        ProccessJump();
        // If reduce input on air is not done uncomment this
        input.x = appliedForce.x + horizontalAxis;
        AddGravity();
        if (appliedForce.magnitude > 0)
        {
            DecreaseAppliedForce();
        }
        rb.linearVelocity = speed * input;
    }

    private void DecreaseAppliedForce()
    {
        appliedForce.x = DecreaseAppliedForceFloat(appliedForce.x);
        appliedForce.y = DecreaseAppliedForceFloat(appliedForce.y);
    }

    private float DecreaseAppliedForceFloat(float appliedFloat)
    {
        if (appliedFloat < -ForceError)
        {
            appliedFloat -= gravity;
        } else if (appliedFloat > ForceError)
        {
            appliedFloat += gravity;
        } else
        {
            appliedFloat = 0f;
        }
        return appliedFloat;
    }

    private void ProccessJump()
    {
        if (tryJump)
        {
            if (ground.Jump())
            {
                jump = true;
                tryJump = false;
            }
            if (jumpBufferElapsed >= maxJumpBuffer) {
                tryJump = false;
            }
        }
        if (jump)
        {
            input.y = appliedForce.y + initialJumpSpeed;
            jump = false;
        }
    }

    private void AddGravity()
    {
        if (ground.IsGrounded())
        {
            // If reduce input on air is done uncomment this
            // input.x = horizontalAxis;
            input.y = 0f;
        }
        else
        {
            input.y += appliedForce.y + gravity;
            if (input.y < maxGravity)
                input.y = maxGravity;
            // On Air reduce input
            // if (!((input.x < 0 && horizontalAxis < 0) || (input.x > 0 && horizontalAxis > 0)))
            // {
            //     input.x += horizontalAxis / AirFactor;
            // }
        }
    }

    void Reset()
    {
        ground = GetComponentInChildren<GroundManager>();
    }

    public float GetInputX()
    {
        return rb.linearVelocityX;
    }

    public void ApplyForce(Vector2 vector, float force)
    {
        appliedForce = force * vector;
    }

    public void StealthMode()
    {
        if (stealth)
        {
            speed = normalSpeed;
        } else
        {
            speed = stealthSpeed;
        }
        stealth = !stealth;
    }
}
