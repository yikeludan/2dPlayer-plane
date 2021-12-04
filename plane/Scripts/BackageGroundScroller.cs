using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackageGroundScroller : MonoBehaviour
{
  private Material _material;

  public Vector2 vecSpeed;

  private void Awake()
  {
    this._material = this.GetComponent<Renderer>().material;
  }

  private void Update()
  {
    this._material.mainTextureOffset += this.vecSpeed * Time.deltaTime;
  }
}
