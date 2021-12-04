using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ViewPort : MonoBehaviour
{

   public static ViewPort instance;
   public float minX;
   public float minY;
   public float maxX;
   public float maxY;

   private float middleX;

   private Camera mainCamera;

   private void Awake()
   {
      instance = this;
   }

   void Start()
   {
      this.mainCamera =Camera.main;
      Vector2 bottomVec2 = this.mainCamera.ViewportToWorldPoint(new Vector3(0, 0));
      this.minX = bottomVec2.x;
      this.minY = bottomVec2.y;
      Vector2 topVec2 = this.mainCamera.ViewportToWorldPoint(new Vector3(1, 1));
      this.maxX = topVec2.x;
      this.maxY = topVec2.y;
      this.middleX = this.mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0, 0)).x;
   }

   public Vector3 PlayMovePostion(Vector3 playerPos)
   {
      Vector3 postion = Vector3.zero;
      postion.x = Mathf.Clamp(playerPos.x, minX, maxX);
      postion.y = Mathf.Clamp(playerPos.y, minY, maxY);
      return postion;
   }



   public Vector3 randomEmenyMovePos(float paddingX, float paddingY)
   {
      Vector3 pos = Vector3.zero;
      pos.x = this.maxX + paddingX;
      pos.y = Random.Range(this.minY + paddingY, this.maxY - paddingY);
      return pos;
   }
   public Vector3 randomRightHalfMovePos(float paddingX, float paddingY)
   {
      Vector3 pos = Vector3.zero;
      pos.x = Random.Range(this.middleX + paddingX, this.maxX - paddingX);
      pos.y = Random.Range(this.minY + paddingY, this.maxY - paddingY);
      return pos;
   }
   public Vector3 randomMovePos(float paddingX, float paddingY)
   {
      Vector3 pos = Vector3.zero;
      pos.x = Random.Range(this.minX + paddingX, this.maxX - paddingX);
      pos.y = Random.Range(this.minY + paddingY, this.maxY - paddingY);
      return pos;
   }

}
