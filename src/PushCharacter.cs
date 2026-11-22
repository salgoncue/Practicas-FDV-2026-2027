using UnityEngine;

public class PushCharacter : MonoBehaviour
{
    [SerializeField] float pushForce = 5f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // collision.rigidbody.AddForce(pushForce * -collision.GetContact(0).normal, ForceMode2D.Impulse);
            Movement movement = collision.gameObject.GetComponent<Movement>();
            ContactPoint2D contact = collision.GetContact(0);
            movement.ApplyForce((-contact.normal).normalized, pushForce);
            // Debug.LogError("APLICA FUERRZA");
        }
    }
}
