using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour {

    public ObjectPool Pool { get; set; }

    public void ReturnToPool()
    {
        if (Pool)
        {
            Pool.AddObject(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public T GetPooledInstance<T>() where T : PooledObject
    {
        if (!poolInstanseForPrefab)
        {
            poolInstanseForPrefab = ObjectPool.GetPool(this);
        }
        return (T)poolInstanseForPrefab.GetObject();
    }



    [System.NonSerialized]
    ObjectPool poolInstanseForPrefab;
}

