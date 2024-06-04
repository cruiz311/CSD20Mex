using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolControl : MonoBehaviour
{
    public GameObject Prefab;
    public int initialPoolSize = 10;

    private Queue<GameObject> poolQueue;

    void Awake()
    {
        poolQueue = new Queue<GameObject>();

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject obj = Instantiate(Prefab);
            obj.SetActive(false);
            poolQueue.Enqueue(obj);
        }
    }
    public GameObject GetObject()
    {
        if (poolQueue.Count > 0)
        {
            GameObject obj = poolQueue.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            initialPoolSize++;
            GameObject obj = Instantiate(Prefab);
            return obj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        poolQueue.Enqueue(obj);
    }
}
