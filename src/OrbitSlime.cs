using UnityEngine;
public class OrbitSlime : MonoBehaviour
{
    Transform target;
    [SerializeField] float speed = 1f;
    float magnitude = 2.5f;
    float interpolate;

    void Start()
    {
        target = transform.parent;
        interpolate = 0f;
    }

    void FixedUpdate () 
    {
        float x = Mathf.Cos(speed * interpolate);
        float y = Mathf.Sin(speed * interpolate);
        interpolate += Time.fixedDeltaTime;
        if (interpolate >= 2 * Mathf.PI)
            interpolate = 0f;
        // transform.Translate(magnitude * Time.fixedDeltaTime * new Vector3(x, y, 0).normalized, target);
        transform.position = magnitude * new Vector3(x, y, 0).normalized + target.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("MASCOTA TOCA JUGADOR");
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.LogWarning("MASCOTA TOCA JUGADOR");
        }
    }
}
