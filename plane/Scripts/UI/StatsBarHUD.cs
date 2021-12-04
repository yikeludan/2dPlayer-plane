using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsBarHUD : StatsBar
{
   public Text prectText;

   private void SetText()
   {
      this.prectText.text = Mathf.RoundToInt(this.targetFillAmount * 100f) + "%";
   }

   public override void Initialazle(float currentValue, float maxValue)
   {
      base.Initialazle(currentValue, maxValue);
      this.SetText();
   }

   protected override IEnumerator BufferFillCoroution(Image image)
   {
      this.SetText();
      return base.BufferFillCoroution(image);
   }
}
