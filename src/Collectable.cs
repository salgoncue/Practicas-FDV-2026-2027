using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] int heal = 25;
    public DamageManager.ChangeHealth OnHealPlayer;
    public GUIManager.Increment OnCollectableObtained;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnHealPlayer(heal);
            OnCollectableObtained();
            gameObject.SetActive(false);
        }
    }
}
