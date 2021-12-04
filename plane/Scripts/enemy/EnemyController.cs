using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{

    public float paddingX;
    
    public float paddingY;

    public float moveRotation;

    public float moveSpeed;

    public float minFileTime;
    
    public float maxFileTime;

    public GameObject[] bullets;

    public Transform muzzle;
   private void OnEnable()
   {
      StartCoroutine(nameof(randomMove));
      StartCoroutine(nameof(randomFire));
   }

   private void OnDisable()
   {
       StopAllCoroutines();
   }

   IEnumerator  randomMove()
   {
       
       this.transform.position = 
           ViewPort.instance.randomEmenyMovePos(this.paddingX, this.paddingY);
       Vector3 targetPos = ViewPort.instance.randomRightHalfMovePos(this.paddingX, this.paddingY);
       while (gameObject.activeSelf)
       {
           if (Vector3.Distance(this.transform.position, targetPos) >= this.moveSpeed * Time.fixedDeltaTime)
           {
              this.transform.position = 
                  Vector3.MoveTowards(this.transform.position, targetPos, this.moveSpeed * Time.fixedDeltaTime);
              this.transform.rotation = Quaternion.AngleAxis((targetPos - this.transform.position).normalized.y 
                                                             * moveRotation,Vector3.right);
           }
           else
           {
               targetPos = ViewPort.instance.randomRightHalfMovePos(this.paddingX, this.paddingY);
           }

           yield return new WaitForFixedUpdate();
       }
   }

   IEnumerator randomFire()
   {
       while (gameObject.activeSelf)
       {
           float time = Random.Range(this.minFileTime, this.maxFileTime);
           yield return new WaitForSeconds(time);
           foreach (var bullet in this.bullets)
           {
               PoolManager.Release(bullet, this.muzzle.transform.position);
           }

         
       }
   }
}
