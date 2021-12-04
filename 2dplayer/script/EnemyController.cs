  using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //print("Enemy");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //print("Enemy12");

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        print("Enemyc");
    }
}
