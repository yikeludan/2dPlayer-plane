using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SenceLoad : PersisterSingletion<SenceLoad>
{
   [SerializeField]  Image trImage;
   [SerializeField]  float fadeTime = 2f;

   private Color color;

   
   void load(string name)
   {
      SceneManager.LoadScene(name);
   }

   IEnumerator LoadContriot()
   {
      var loading =  SceneManager.LoadSceneAsync("GamePlay");
      loading.allowSceneActivation = false;
      this.trImage.gameObject.SetActive(true);
      while (this.color.a<1f)
      {
         this.color.a = Mathf.Clamp01(this.color.a + Time.unscaledDeltaTime / this.fadeTime);
         this.trImage.color = color;
         yield return null;
      }

      loading.allowSceneActivation = true;
      while (this.color.a>0)
      {
         this.color.a = Mathf.Clamp01(this.color.a - Time.unscaledDeltaTime / this.fadeTime);
         this.trImage.color = color;
         yield return null;
      }
      this.trImage.gameObject.SetActive(false);
   }

   public void LoadGameScene()
   {
      StartCoroutine(LoadContriot());
   }
}
