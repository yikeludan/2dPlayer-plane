using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : PersisterSingletion<AudioManager>
{
   [SerializeField] private AudioSource SFXPLayer;

   

   public void playSFX(AudioClip audioClip, float volume)
   {
     // this.SFXPLayer.pitch = Random.Range(0.9f, 1.1f);
      this.SFXPLayer.PlayOneShot(audioClip,volume);
   }
}
