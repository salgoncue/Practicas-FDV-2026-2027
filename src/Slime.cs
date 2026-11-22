using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

[RequireComponent(typeof(Rigidbody2D))]
public class Slime : MonoBehaviour
{
    LineRenderer chain;
    GameObject slime;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform player;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chain = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        slime = transform.GetChild(0).gameObject;
        chain.SetPosition(0, Vector2.zero);
        chain.SetPosition(1, slime.transform.position - transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        chain.SetPosition(1, slime.transform.position - transform.position);
    }

    void FixedUpdate()
    {
        rb.MovePosition(speed * Time.fixedDeltaTime * (player.position - transform.position).normalized + transform.position);
    }

    void Reset()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
}
