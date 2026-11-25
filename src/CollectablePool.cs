using UnityEngine;

public class CollectablePool : MonoBehaviour
{
    public delegate void Collectable(GameObject gameObject);
    public Collectable OnCollect;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCollect(gameObject);
            gameObject.SetActive(false);
        }
    }
}
