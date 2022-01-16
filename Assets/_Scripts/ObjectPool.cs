using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private readonly Dictionary<string, Queue<GameObject>> _objectPool = new Dictionary<string, Queue<GameObject>>();
    public static ObjectPool Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject GetObject(GameObject prefab)
    {
        if (_objectPool.TryGetValue(prefab.name, out Queue<GameObject> objectList))
        {
            if (objectList.Count == 0)
                return CreateNewObject(prefab);
            else
            {
                GameObject go = objectList.Dequeue();
                go.SetActive(true);
                return go;
            }
        }
        else
            return CreateNewObject(prefab);
    }

    private GameObject CreateNewObject(GameObject prefab)
    {
        GameObject newGO = Instantiate(prefab);
        newGO.name = prefab.name;
        return newGO;
    }

    public void ReturnGameObject(GameObject createdGameObject)
    {
        if (_objectPool.TryGetValue(createdGameObject.name, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(createdGameObject);
        }
        else
        {
            Queue<GameObject> newObjectQueue = new Queue<GameObject>();
            newObjectQueue.Enqueue(createdGameObject);
            _objectPool.Add(createdGameObject.name, newObjectQueue);
        }

        createdGameObject.SetActive(false);

    }
}
