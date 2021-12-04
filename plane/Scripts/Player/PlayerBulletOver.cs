using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerBulletOver : PlayerBullet
{

   public ProjectGuideSystem projectGuideSystem;
   protected override void OnEnable()
   {
      
      SetTarget(EnemyManager.instance.RandomEnery);
      this.transform.rotation = quaternion.identity;
      if (target == null)
      {
         base.OnEnable();
      }
      else
      {
         StartCoroutine(projectGuideSystem.HomingCro(target));
      }
   }
}
