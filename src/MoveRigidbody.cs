using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveRigidbody : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody rb;
    private Vector3 input = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.z = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.linearVelocity = speed * input;
        // rb.MovePosition(Time.fixedDeltaTime * speed * input + rb.position);
    }
}
