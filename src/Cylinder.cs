using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cylinder : MonoBehaviour
{
    [SerializeField] Transform goal;
    [SerializeField] float speed = 5f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = speed * (goal.position - rb.position).normalized;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Goal") && !collision.gameObject.CompareTag("Plane"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            Rigidbody collisionRb = collision.gameObject.GetComponent<Rigidbody>();
            collisionRb.MovePosition(speed * collision.gameObject.transform.forward + collisionRb.position);
        }
    }

    void Reset()
    {
        goal = GameObject.FindWithTag("Goal").transform;
    }
}
