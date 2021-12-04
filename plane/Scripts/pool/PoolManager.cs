using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    public Pool[] pools;
    public Pool[] enemeyPools;
    public Pool[] vfxPools;
    public Pool[] eneryPlayerPools;

    

    static Dictionary<GameObject, Pool> dictionary;

    void Init(Pool[] pools)
    {
        foreach (var pool in pools)
        {
            if (dictionary.ContainsKey(pool.Prefab))
            {
                continue;
            }
            dictionary.Add(pool.Prefab,pool);
            Transform poolParent = new GameObject("name = " + pool.Prefab.name).transform;
            poolParent.parent = this.transform;
            pool.Init(poolParent);
        }
    }

    void Awake()
    {
        dictionary = new Dictionary<GameObject, Pool>();
        this.Init(pools);
        this.Init(enemeyPools);
        this.Init(vfxPools);
        this.Init(eneryPlayerPools);
    }

    public static GameObject Release(GameObject prefab)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            return null;
        }

        return dictionary[prefab].prefabObject();
    }
    
    public static GameObject Release(GameObject prefab,Vector3 vector3)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            return null;
        }

        return dictionary[prefab].prefabObject(vector3);
    }
    public static GameObject Release(GameObject prefab,Vector3 vector3,Quaternion quaternion)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            return null;
        }

        return dictionary[prefab].prefabObject(vector3,quaternion);
    }
    
    public static GameObject Release(GameObject prefab,Vector3 vector3,Quaternion quaternion,Vector3 localScale)
    {
        if (!dictionary.ContainsKey(prefab))
        {
            return null;
        }

        return dictionary[prefab].prefabObject(vector3,quaternion,localScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
