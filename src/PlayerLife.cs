using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] DamageManager damageManager;
    [SerializeField] int maxLife = 50;
    public DamageManager.ChangeHealth OnMaxLifeChanged;
    public DamageManager.ChangeHealth OnActualLifeChanged;

    int actualLife;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actualLife = maxLife;
        damageManager.OnDamagePlayer += DamagePlayer;
        damageManager.OnHealPlayer += HealPlayer;
    }

    void DamagePlayer(int damage)
    {
        actualLife -= damage;
        OnActualLifeChanged(actualLife);
    }

    void HealPlayer(int health)
    {
        if (actualLife == maxLife)
        {
            return;
        }
        if (actualLife + health >= maxLife)
        {
            actualLife = maxLife;
        } else
        {
            actualLife += health;
        }
        OnActualLifeChanged(actualLife);
    }

    void SetMaxLife(int newMax, bool heal = false)
    {
        maxLife = newMax;
        OnMaxLifeChanged(maxLife);
        if (heal) {
            actualLife = maxLife;
            OnActualLifeChanged(actualLife);
        }
    }

    public void IncreaseLife(int increment = 50)
    {
        SetMaxLife(maxLife + increment, true);
    }

    // public int GetMaxLife()
    // {
    //     return maxLife;
    // }

    // public int GetLife()
    // {
    //     return actualLife;
    // }
}
