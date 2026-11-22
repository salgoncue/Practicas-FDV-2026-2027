using UnityEngine;

public class Ejercicio3Rotacion : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 3f;
    [SerializeField] Space space = Space.Self;
    float horizontalAxis;
    float verticalAxis;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontalAxis = 0f;
        verticalAxis = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        transform.Rotate(horizontalAxis * rotationSpeed * Time.deltaTime * Vector3.forward);
        transform.Translate(verticalAxis * speed * Time.deltaTime * Vector3.up, space);
    }
}
