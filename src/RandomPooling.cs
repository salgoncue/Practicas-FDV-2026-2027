using System.Collections.Generic;
using UnityEngine;

public class RandomPooling : MonoBehaviour
{
    [SerializeField] Pool objectPool;
    [SerializeField] int maxObjects = 5;
    int objectsActives;
    bool spawnObjects;
    BoxCollider2D boxCollider2D;
    Stack<GameObject> objects = new Stack<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnObjects = false;
        objectsActives = 0;
        objects = objectPool.GetPrefabsForIndex(0);
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        if (spawnObjects && objectsActives < maxObjects)
        {
            GameObject gameObject = objects.Pop();
            Bounds bounds = boxCollider2D.bounds;
            gameObject.transform.position = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), 0);
            gameObject.GetComponent<CollectablePool>().OnCollect += BackToPool;
            gameObject.SetActive(true);
            ++objectsActives;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spawnObjects = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spawnObjects = false;
        }
    }

    void BackToPool(GameObject gameObject)
    {
        gameObject.GetComponent<CollectablePool>().OnCollect -= BackToPool;
        objects.Push(gameObject);
        --objectsActives;
    }
}
