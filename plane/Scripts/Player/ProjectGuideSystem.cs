using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectGuideSystem : MonoBehaviour
{

   public Bullet bullet;

   public float minAnagel = 50f;

   public float maxAnagel = 75f;

   private float rangeAngel;
   
   private Vector3 dir;
   public IEnumerator HomingCro(GameObject target)
   {
      this.rangeAngel = Random.Range(this.minAnagel, this.maxAnagel);
      while (gameObject.activeSelf)
      {
         if (target.activeSelf)
         {
            dir = target.transform.position - this.transform.position;
            var angel = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angel, Vector3.forward);
            this.transform.rotation *=Quaternion.Euler(0,0,rangeAngel);
            bullet.Move();
         }
         else
         {
            bullet.Move();
         }
         yield return null;
      }
   }
}
