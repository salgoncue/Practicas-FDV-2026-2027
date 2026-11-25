using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    public delegate void Deactivated(Bullet bullet);
    public Deactivated OnDeactivate;
    bool alreadyDeactivated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        alreadyDeactivated = false;
    }
    void OnEnable()
    {
        StartCoroutine(Deactivate().GetEnumerator());
        alreadyDeactivated = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocityX = speed * (transform.rotation.y == 0f ? 1 : -1);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (alreadyDeactivated) 
            return;
        StopAllCoroutines();
        OnDeactivate(this);
        alreadyDeactivated = true;
        gameObject.SetActive(false);
    }

    IEnumerable Deactivate()
    {
        yield return new WaitForSeconds(1.5f);
        OnDeactivate(this);
        alreadyDeactivated = true;
        gameObject.SetActive(false);
    }
}
