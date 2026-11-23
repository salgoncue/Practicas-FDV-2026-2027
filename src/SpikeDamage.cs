using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    [SerializeField] int damage = 10;
    public DamageManager.ChangeHealth OnDamagePlayer;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnDamagePlayer(damage);
        }
    }
}
