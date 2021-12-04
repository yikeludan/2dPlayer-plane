using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
    public Image fillImageBack;

    public Image fillImageFront;


    public float currentFillAmount;

    public float targetFillAmount;

    public float fillSpeed = 0.1f;

    private Canvas canvas;

    private float t;

    private WaitForSeconds waitForDelayFill;

    private float fillDelay = 0.5f;

    private bool delayFill = true;

    private Coroutine fillCoroutine;

    protected float prefillAmount;
    
    private void Awake()
    {
        this.canvas = this.GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        this.waitForDelayFill = new WaitForSeconds(this.fillDelay);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public virtual void Initialazle(float currentValue,float maxValue)
    {
        this.currentFillAmount = currentValue / maxValue;
        this.targetFillAmount = currentFillAmount;
        this.fillImageBack.fillAmount = currentFillAmount;
        this.fillImageFront.fillAmount = currentFillAmount;

    }
    
    public void updateStatus(float currentValue,float maxValue)
    {
        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine);
        }

        this.targetFillAmount = currentValue / maxValue;
        if (this.currentFillAmount > this.targetFillAmount)
        {
            this.fillImageFront.fillAmount = this.targetFillAmount;
            fillCoroutine = StartCoroutine(BufferFillCoroution(fillImageBack));
        }
        if (this.currentFillAmount < this.targetFillAmount)
        {
            this.fillImageFront.fillAmount = this.targetFillAmount;
            fillCoroutine = StartCoroutine(BufferFillCoroution(fillImageFront));
        }
    }

    protected  virtual IEnumerator  BufferFillCoroution(Image image)
    {
        if (this.delayFill)
        {
            yield return this.waitForDelayFill;
        }
        t = 0f;
        prefillAmount = currentFillAmount;
        while (t<1f)
        {
            t += Time.deltaTime * this.fillDelay;
            this.currentFillAmount = Mathf.Lerp(prefillAmount, this.targetFillAmount, t);
            image.fillAmount = currentFillAmount;
            yield return null;
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
