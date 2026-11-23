using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [SerializeField] Collectable[] collectables;
    [SerializeField] SpikeDamage spikeDamage;
    public delegate void ChangeHealth(int damage);
    public ChangeHealth OnDamagePlayer;
    public ChangeHealth OnHealPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < collectables.Length; ++i)
        {
            collectables[i].OnHealPlayer += HealDealtToPLayer;
        }
        spikeDamage.OnDamagePlayer += DamageDealtToPlayer;
    }

    void DamageDealtToPlayer(int damage)
    {
        OnDamagePlayer(damage);
    }

    void HealDealtToPLayer(int heal)
    {
        OnHealPlayer(heal);
    }

    public Collectable[] GetCollectables()
    {
        return collectables;
    }
}
