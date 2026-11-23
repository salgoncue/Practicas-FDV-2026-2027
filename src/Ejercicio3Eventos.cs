using UnityEngine;

public class Ejercicio3Eventos : MonoBehaviour
{
    [SerializeField] InterpolateForCamera batPlayer;
    [SerializeField] InterpolateForCamera batInstant;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            batPlayer.SetDestination(collision.gameObject.transform.position);
            batPlayer.StartMovement();
            batInstant.StartMovement();
        }
    }
}
