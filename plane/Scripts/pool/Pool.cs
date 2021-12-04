using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public GameObject Prefab => prefab;
    public GameObject tempPrefab;
    public GameObject prefab;

    public int size = 1;

    private Queue<GameObject> queue;

    private Transform parent;


    public void Init(Transform parent)
    {
        this.queue =  new Queue<GameObject>();
        this.parent = parent;
        for (var i = 0; i < size; i++)
        {
            queue.Enqueue(Copy());
        }
    }

    GameObject Copy()
    {
        var copy = GameObject.Instantiate(prefab,parent);
        copy.SetActive(false);
        return copy;
    }


    GameObject AvailableObject()
    {
        GameObject availableGameObject = null;
        if (this.queue.Count > 0 && !this.queue.Peek().activeSelf)
        {
            availableGameObject = this.queue.Dequeue();
        }
        else
        {
            availableGameObject = this.Copy();
        }
        this.queue.Enqueue(availableGameObject);
        return availableGameObject;
    }
    
    public GameObject prefabObject()
    {
        GameObject pre = AvailableObject();
        pre.SetActive(true);
        return pre;
    }

    public GameObject prefabObject(Vector3 vector3)
    {
        GameObject pre = AvailableObject();
        pre.SetActive(true);
        pre.transform.position = vector3;
        return pre;
    }
    
    public GameObject prefabObject(Vector3 vector3,Quaternion quaternion)
    {
        GameObject pre = AvailableObject();
        pre.SetActive(true);
        pre.transform.position = vector3;
        pre.transform.rotation = quaternion;
        return pre;
    }
    
    public GameObject prefabObject(Vector3 vector3,Quaternion quaternion,Vector3 localScale)
    {
        GameObject pre = AvailableObject();
        pre.SetActive(true);
        pre.transform.position = vector3;
        pre.transform.rotation = quaternion;
        pre.transform.localScale = localScale;
        return pre;
    }


    public void Return(GameObject gameObject)
    {
        this.queue.Enqueue(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
