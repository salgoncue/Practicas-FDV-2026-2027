using UnityEngine;

public class InterpolateForCamera : MonoBehaviour
{
    [SerializeField] Vector3 startingPosition = new();
    [SerializeField] Vector3 finalPosition = new();
    [SerializeField] bool once = false;
    [SerializeField] bool fromStart = true;
    [SerializeField] bool instant = false;
    bool done;
    Vector3 target = new();
    bool reverse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        done = false;
        reverse = false;
        target = finalPosition;
    }

    // Update is called once per frame
    void Update()
    {
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
            transform.position = target;
            target = reverse ? startingPosition : finalPosition;
            reverse = !reverse;
            if (once && !done)
            {
                done = true;
            }
            return;
        }
        transform.Translate(Time.deltaTime * (target - transform.position).normalized);
        if ((target - transform.position).magnitude < 0.1f)
        {
            target = reverse ? startingPosition : finalPosition;
            reverse = !reverse;
            if (once && !done)
            {
                done = true;
            }
        }
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
