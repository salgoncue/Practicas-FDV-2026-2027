using UnityEngine;

public class InterpolateForCamera : MonoBehaviour
{
    [SerializeField] Vector3 startingPosition = new();
    [SerializeField] Vector3 finalPosition = new();
    Vector3 target = new();
    bool reverse;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reverse = false;
        target = finalPosition;
    }

    // Update is called once per frame
    void Update()
    {
            transform.Translate(Time.deltaTime * (target - transform.position).normalized);
            if ((target - transform.position).magnitude < 0.1f)
            {
                target = reverse ? startingPosition : finalPosition;
                reverse = !reverse;
            }
    }
}
