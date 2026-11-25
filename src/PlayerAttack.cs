using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerAttack : MonoBehaviour
{
    bool startAttack;
    bool attacking;
    Transform bulletSpawner;
    [SerializeField] Pool bulletPool;
    Movement movement;
    public delegate void Attack();
    public Attack OnAttack;
    public Attack OnEndAttack;
    Vector3 startingPositionSpawner;
    Vector3 reversePositionSpawner;
    Stack<GameObject> bullets = new Stack<GameObject>();
    [SerializeField] Ejercicio4Mecanicas ejercicio4Mecanicas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startAttack = false;
        attacking = false;
        bulletSpawner = transform.GetChild(1);
        movement = GetComponent<Movement>();
        movement.OnFlip += FlipSpawner;
        startingPositionSpawner = bulletSpawner.position;
        reversePositionSpawner = new(-startingPositionSpawner.x, startingPositionSpawner.y, 0);
        bullets = bulletPool.GetPrefabsForIndex(0);
        ejercicio4Mecanicas.OnChoque += InstantiateBullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking && bullets.Count > 0 && Input.GetMouseButtonDown(0))
        {
            startAttack = true;
        }
    }

    void FixedUpdate()
    {
        if (startAttack)
        {
            startAttack = false;
            attacking = true;
            OnAttack();
        }
    }

    void FlipSpawner(bool flip)
    {      
        if (flip)
        {
            bulletSpawner.SetLocalPositionAndRotation(reversePositionSpawner, Quaternion.Euler(0, 180, 0));
        } else
        {
            bulletSpawner.SetLocalPositionAndRotation(startingPositionSpawner, Quaternion.Euler(0, 0, 0));
        }
    }

    public void InstantiateBullet()
    {
        // SpawnBullet
        GameObject bullet = bullets.Pop();
        bullet.transform.SetPositionAndRotation(bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().OnDeactivate += DeactivateBullet;
        // movement.DeactivateSprite();
        // gameObject.SetActive(false);
    }

    void DeactivateBullet(Bullet bullet)
    {
        bullet.OnDeactivate -= DeactivateBullet;
        bullets.Push(bullet.gameObject);
    }

    public void End()
    {
        attacking = false;
        OnEndAttack();
    }
}
