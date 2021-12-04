using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDisable : MonoBehaviour
{
    private float lifeTime = 3f;
    private WaitForSeconds waitForSeconds;

    public bool isDisable;

    

    private void Awake()
    {
        this.waitForSeconds = new WaitForSeconds(this.lifeTime);
    }

    private void OnEnable()
    {
        StartCoroutine(DestoryBullet());
    }

    void Start()
    {
        
    }

    IEnumerator DestoryBullet()
    {
        yield return this.waitForSeconds;
        if (this.isDisable)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
