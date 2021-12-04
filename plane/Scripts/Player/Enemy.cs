using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Chacter
{
    public int deathEnergeBouns = 3;


    public AudioClip dieSound;
    public override void Die()
    {
        PlayerEnery.instance.Obtain(deathEnergeBouns);
        EnemyManager.instance.RemoveList(gameObject);
        AudioManager.Instance.playSFX(this.dieSound,1f);
        ScoreManager.Instance.addScore(20);
        base.Die();
      
    }
}
