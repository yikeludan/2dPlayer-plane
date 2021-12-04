using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SArea : MonoBehaviour
{
    public bool isSarea;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("redHat"))
        {
            isSarea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("redHat"))
        {
            isSarea = false;
        }
    }
}
