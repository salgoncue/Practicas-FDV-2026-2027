using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] uint totalOfObjectsPerPrefab = 0;
    Stack<GameObject>[] gameObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObjects = new Stack<GameObject>[prefabs.Length];
        for (int i = 0; i < gameObjects.Length; ++i)
        {
            gameObjects[i] = new Stack<GameObject>();
            for (int j = 0; j < totalOfObjectsPerPrefab; ++j)
            {
                gameObjects[i].Push(GameObject.Instantiate(prefabs[i], transform));
            }
        }
    }

    public Stack<GameObject> GetPrefabsForIndex(int i)
    {
        if (i < 0 || i >= totalOfObjectsPerPrefab)
        {
            return null;
        }
        return gameObjects[i];
    }

    public Stack<GameObject>[] GetAllPrefabs()
    {
        return gameObjects;
    }
}
