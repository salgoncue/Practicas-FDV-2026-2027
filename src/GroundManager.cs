using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField] bool isGrounded;
    [SerializeField] bool hasCoyote;
    Vector2 raycastOrigin;
    readonly float raycastLength = 0.05f;
    [SerializeField] int totalRays = 3;
    [SerializeField] LayerMask collisionLayer;
    readonly float margin = 0.0025f;
    float raySpacing;
    Collider2D parentCollider;
    readonly float maxCoyoteTime = 0.5f;
    float coyoteElapsed;
    float groundMargin;
    bool hitGround;
    bool onPlatform;
    public delegate void GroundHit(Transform platform);
    public GroundHit OnPlatform;
    public GroundHit OnLeavePlatform;

    void Start()
    {
        groundMargin = raycastLength * 2;
        hitGround = false;
        isGrounded = false;
        hasCoyote = false;
        onPlatform = false;
        coyoteElapsed = maxCoyoteTime;
        parentCollider = transform.parent.GetComponent<CompositeCollider2D>();
        CalculateRaySpacing();
    }

    void Update()
    {
        UpdateRaycastOrigin();
        hitGround = false;
        for (int i = 0; i < totalRays; ++i)
        {
            Debug.DrawRay(raycastOrigin + Vector2.right * raySpacing * i, Vector2.up * -raycastLength, Color.red);
            RaycastHit2D hit2D = Physics2D.Raycast(raycastOrigin + Vector2.right * raySpacing * i, Vector2.up * -1f, raycastLength, collisionLayer);

            if (hit2D && !hitGround)
            {
                hitGround = true;
                Rigidbody2D rb = transform.parent.GetComponent<Rigidbody2D>();
                rb.linearVelocityY = (hit2D.distance - margin) * -1;
                groundMargin = hit2D.distance - margin;
                if (!onPlatform && hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Platforms"))
                {
                    OnPlatform(hit2D.collider.gameObject.transform);
                    onPlatform = true;
                }
            }
        }
        if (hitGround && !isGrounded && groundMargin < 0.03f)
        {
            isGrounded = true;
            hasCoyote = true;
        } else if (!hitGround && isGrounded)
        {
            isGrounded = false;
            coyoteElapsed = 0f;
        }
        if (onPlatform && !isGrounded)
        {
            onPlatform = false;
            OnLeavePlatform(null);
        }
    }

    void FixedUpdate()
    {
        if (!isGrounded && hasCoyote)
        {
            if (coyoteElapsed < maxCoyoteTime)
            {
                coyoteElapsed += Time.fixedDeltaTime;
            } else
            {
                hasCoyote = false;
            }
        }
    }

    void UpdateRaycastOrigin()
    {
        Bounds bounds = parentCollider.bounds;
        bounds.Expand(margin * -2);
        raycastOrigin = bounds.min;
    }

    void CalculateRaySpacing()
    {
        Bounds bounds = parentCollider.bounds;
        bounds.Expand(margin * -2);
        raySpacing = bounds.size.x / (totalRays - 1);
    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //     {
    //         // Debug.Log("IN");
    //         isGrounded = true;
    //         hasCoyote = true;
    //     }
    // }

    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
    //     {
    //         // Debug.Log("OUT");
    //         isGrounded = false;
    //         coyoteElapsed = 0f;
    //     }
    // }

    bool CanJump()
    {
        if (isGrounded || hasCoyote)
        {
            return true;
        }
        return false;
    }

    public bool Jump()
    {
        if (CanJump())
        {
            hasCoyote = false;
            isGrounded = false;
            return true;
        }
        return false;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public bool IsPlatform()
    {
        return onPlatform;
    }
}