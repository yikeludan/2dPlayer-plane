using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    
    void Awake()
    {
        if (vector2 != Vector2.left)
        {
            this.transform.rotation = 
                Quaternion.FromToRotation(Vector2.left, vector2);
        }
    }

   
}
