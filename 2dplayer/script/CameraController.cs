using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform target;

    private float moveSpeed = 2f;

    private float max = 7.1f;

    private float min = -6.5f;

    
        
    private void Awake()
    {
    
        this.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Start()
    {
        
    }

  
    void LateUpdate()
    {
        
    
        Vector3 dir = new Vector3(this.target.position.x, this.transform.position.y, this.transform.position.z);

        //dir.x = rangeX;
        this.transform.position = Vector3.Lerp(this.transform.position, dir, this.moveSpeed * Time.deltaTime);
        float rangeX = Mathf.Clamp(this.transform.position.x, this.min, this.max);
        this.transform.position = new Vector3(rangeX, this.transform.position.y, this.transform.position.z);
        //  this.transform.position = dir;
    }
  
}
