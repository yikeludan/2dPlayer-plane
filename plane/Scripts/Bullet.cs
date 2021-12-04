using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;

    public GameObject hitVFX;
    public Vector2 vector2;


    protected GameObject target;
    
 
    
    

   

    protected  virtual  void OnEnable()
    {
        StartCoroutine(moveDir());
    }

    


    IEnumerator moveDir()
    {
        while (true)
        {
            this.Move();
            yield return null;
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.TryGetComponent<Chacter>(out Chacter chacter))
        {
            chacter.TakeDamage(1);
            var collPoint = collision2D.GetContact(0);
            PoolManager.Release(this.hitVFX, collPoint.point, Quaternion.LookRotation(collPoint.normal));
            gameObject.SetActive(false);
        }
    }

   protected void SetTarget(GameObject Target)
    {
        this.target = Target;
    }

   public void Move()
   {
       this.transform.Translate(this.vector2 * this.moveSpeed* Time.deltaTime);

   }
}
