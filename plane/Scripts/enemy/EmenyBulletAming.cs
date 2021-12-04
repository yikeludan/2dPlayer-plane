using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyBulletAming : Bullet
{
    private void Awake()
    {
        this.target = GameObject.FindGameObjectWithTag("Player");
        
    }

    protected override void OnEnable()
    {
        StartCoroutine(nameof(moveDirRoation));
        base.OnEnable();
    }

    /*private void Update()
    {
        Vector3 dir = this.target.transform.position - this.transform.position;
        dir = dir.normalized;
        this.transform.LookAt(dir);
        this.transform.Translate(dir *5f *Time.deltaTime);
    }*/


    IEnumerator moveDirRoation()
    {
        yield return null;
        if (this.target.activeSelf)
        {
            this.vector2 = (target.transform.position - transform.position).normalized;
        }
       
       
    }

}
    
