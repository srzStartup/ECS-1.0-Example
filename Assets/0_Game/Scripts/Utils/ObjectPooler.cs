using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-3)]
public class ObjectPooler : Singleton<ObjectPooler>
{
    [SerializeField] private Dictionary<string, Queue<GameObject>> poolDictionary;
    [SerializeField] private List<Pool> pools;

    //[SerializeField] private Pool<CollectibleText> collectibleTextPool;
    //private Queue<CollectibleText> collectibleTextQueue;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> poolQueue = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject go = Instantiate(pool.prefab);
                if (pool.parent)
                    go.transform.SetParent(pool.parent, pool.worldPositionStays);
                go.SetActive(false);
                poolQueue.Enqueue(go);
            }

            poolDictionary.Add(pool.tag, poolQueue);
        }

        //collectibleTextQueue = new Queue<CollectibleText>();
        //for (int i = 0; i < collectibleTextPool.size; i++)
        //{
        //    CollectibleText collectibleText = Instantiate(collectibleTextPool.prefab);
        //    if (collectibleTextPool.parent)
        //        collectibleText.rectTransform.SetParent(collectibleTextPool.parent, collectibleTextPool.worldPositionStays);
        //    collectibleText.rectTransform.gameObject.SetActive(false);
        //    collectibleTextQueue.Enqueue(collectibleText);
        //}
    }

    //public CollectibleText SpawnFromPool(Vector3 position, Quaternion rotation, bool isActive = true, bool instantEnqueue = false)
    //{
    //    if (collectibleTextQueue.Count != 0)
    //    {
    //        CollectibleText spawned = collectibleTextQueue.Dequeue();

    //        spawned.rectTransform.SetPositionAndRotation(position, rotation);

    //        spawned.gameObject.SetActive(isActive);

    //        if (instantEnqueue)
    //            collectibleTextQueue.Enqueue(spawned);

    //        return spawned;
    //    }
    //    else return null;
    //}

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, bool isActive = true, bool instantEnqueue = false)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        if (poolDictionary[tag].Count != 0)
        {
            GameObject spawned = poolDictionary[tag].Dequeue();

            spawned.transform.SetPositionAndRotation(position, rotation);

            if (isActive)
                spawned.SetActive(true);

            if (instantEnqueue)
                poolDictionary[tag].Enqueue(spawned);

            return spawned;
        }
        else
        {
            return null;
        }
    }

    public void PushToQueue(string tag, GameObject go, bool clearParent = true, bool isActive = false)
    {
        if (clearParent)
            go.transform.SetParent(null, false);
        go.SetActive(isActive);

        poolDictionary[tag].Enqueue(go);
    }

    //public void PushCollectibleTextToQueue(CollectibleText collectibleText, bool clearParent, bool isActive = false)
    //{
    //    if (clearParent)
    //        collectibleText.rectTransform.SetParent(null, false);
    //    collectibleText.gameObject.SetActive(isActive);

    //    collectibleTextQueue.Enqueue(collectibleText);
    //}
}

[System.Serializable]
public class Pool
{
    public string tag;
    public int size;
    public GameObject prefab;
    public Transform parent;
    public bool worldPositionStays;
    public bool shouldExpand;
}

[System.Serializable]
public class Pool<T>
{
    public string tag;
    public int size;
    public T prefab;
    public Transform parent;
    public bool worldPositionStays;
    public bool shouldExpand;
}