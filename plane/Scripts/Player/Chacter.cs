using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chacter : MonoBehaviour
{

    public float maxHeath;

    protected float health;

    public GameObject DeathVFX;


    public StatsBar onHeadHealthBar;


    public bool showOnHeadHealthBar = true;


    public void disPlayOnHeadHealthBar()
    {
        this.onHeadHealthBar.gameObject.SetActive(true);
        this.onHeadHealthBar.Initialazle(this.health,this.maxHeath);
    }
    public void disAbleOnHeadHealthBar()
    {
        this.onHeadHealthBar.gameObject.SetActive(false);
    }
    protected  virtual  void OnEnable()
    {
        this.health = this.maxHeath;
        if (this.showOnHeadHealthBar)
        {
            this.disPlayOnHeadHealthBar();
        }
        else
        {
            this.disAbleOnHeadHealthBar();
        }
    }

    public virtual void TakeDamage(float damage)
    {
        this.health -= damage;
        if (this.showOnHeadHealthBar && gameObject.activeSelf)
        {
            this.onHeadHealthBar.updateStatus(health,maxHeath);
        }
        if (this.health <= 0)
        {
            this.Die();
        }
    }

    public virtual void Die()
    {
        this.health = 0;
        PoolManager.Release(DeathVFX,this.transform.position);
        gameObject.SetActive(false);
    }

    public virtual void RestHealth(float resHealth)
    {
        if (this.health == maxHeath)
        {
            return;
        }

        this.health = Mathf.Clamp(this.health + resHealth, 0f, this.maxHeath);
        if (this.showOnHeadHealthBar)
        {
            this.onHeadHealthBar.updateStatus(health,maxHeath);
        }
    }

    protected IEnumerator healthRestCon(WaitForSeconds waitForSeconds, float prec)
    {
        while (this.health < this.maxHeath)
        {
            yield return waitForSeconds;
            this.TakeDamage(this.maxHeath * prec);
        }
    }
    
    protected  IEnumerator DamageOverTime(WaitForSeconds waitForSeconds, float prec)
    {
        while (this.health > 0)
        {
            yield return waitForSeconds;
            this.RestHealth(this.maxHeath * prec);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
