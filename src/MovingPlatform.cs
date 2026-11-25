using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

[RequireComponent(typeof(Platform))]
[RequireComponent(typeof(BoxCollider2D))]
public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Vector2 startingPosition = new();
    [SerializeField] Vector2 finalPosition = new();
    [SerializeField] float speed = 3f;
    [SerializeField] float wait = 3f;
    [SerializeField] bool once = false;
    [SerializeField] bool fromStart = true;
    [SerializeField] bool instant = false;
    Vector2 raycastOrigin;
    readonly float raycastLength = 0.05f;
    [SerializeField] int totalRays = 3;
    [SerializeField] LayerMask collisionLayer;
    readonly float margin = 0.0025f;
    float raySpacing;
    Rigidbody2D rb;
    BoxCollider2D boxCollider2D;
    Movement movement;
    Platform platform;
    float elapsedWait;
    bool done;
    Vector2 target = new();
    bool reverse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        elapsedWait = wait;
        boxCollider2D = GetComponent<BoxCollider2D>();
        done = false;
        reverse = false;
        target = finalPosition;
        rb = GetComponent<Rigidbody2D>();
        platform = GetComponent<Platform>();
        movement = platform.player.GetComponent<Movement>();
        totalRays *= Mathf.RoundToInt(boxCollider2D.bounds.max.x - boxCollider2D.bounds.min.x);
        CalculateRaySpacing();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateRaycastOrigin();
        if (elapsedWait < wait)
        {
            elapsedWait += Time.fixedDeltaTime;
        }
        if (fromStart)
        {
            if (once && !done)
            {
                Move();
            } else if (!once)
            {
                Move();
            }
        }
    }

    private void Move()
    {
        if (instant)
        {
            rb.MovePosition(target);
            target = reverse ? startingPosition : finalPosition;
            reverse = !reverse;
            elapsedWait = 0f;
            if (once && !done)
            {
                done = true;
            }
            return;
        }
        Vector2 velocity = speed * Time.fixedDeltaTime * (target - rb.position).normalized;
        rb.MovePosition(velocity + rb.position);
        if (platform.HasPlayer())
        {
            movement.ApplyForce(velocity, speed * 2f);
        }
        MovePassengers(velocity);
        if ((target - rb.position).magnitude < 0.1f)
        {
            target = reverse ? startingPosition : finalPosition;
            reverse = !reverse;
            elapsedWait = 0f;
            if (once && !done)
            {
                done = true;
            }
        }
    }

    void MovePassengers(Vector2 velocity)
    {
        for (int i = 0; i < totalRays; ++i)
        {
            Debug.DrawRay(raycastOrigin + Vector2.right * raySpacing * i, Vector2.up * -raycastLength, Color.red);
            RaycastHit2D hit2D = Physics2D.Raycast(raycastOrigin + Vector2.right * raySpacing * i, Vector2.up * -1f, raycastLength, collisionLayer);

            if (hit2D)
            {;
                Rigidbody2D rb = transform.parent.GetComponent<Rigidbody2D>();
                rb.linearVelocityY = (hit2D.distance - margin) * -1;
            }
        }
    }

    void UpdateRaycastOrigin()
    {
        Bounds bounds = boxCollider2D.bounds;
        bounds.Expand(margin * -2);
        raycastOrigin = bounds.min;
    }

    void CalculateRaySpacing()
    {
        Bounds bounds = boxCollider2D.bounds;
        bounds.Expand(margin * -2);
        raySpacing = bounds.size.x / (totalRays - 1);
    }

    public void SetDestination(Vector2 destination)
    {
        finalPosition = destination;
        target = finalPosition;
    }

    public void StartMovement()
    {
        if (!fromStart)
            fromStart = true;
    }
}
