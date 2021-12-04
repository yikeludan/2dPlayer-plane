using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackWaveUI : MonoBehaviour
{
   
    
    [Header("---- LINE MOVE ----")]
    [SerializeField] Vector2 lineTopStartPosition = new Vector2(-1250f, 140f);
    [SerializeField] Vector2 lineTopTargetPosition = new Vector2(0f, 140f);
    [SerializeField] Vector2 lineBottomStartPosition = new Vector2(1250f, 0f);
    [SerializeField] Vector2 lineBottomTargetPosition = Vector2.zero;
    [Header("---- TEXT SCALE ----")]
    [SerializeField] Vector2 waveTextStartScale = new Vector2(1f, 0f);
    [SerializeField] Vector2 waveTextTargetScale = Vector2.one;
    [SerializeField] Vector2 waveTextStartScale2 = new Vector2(30f, 30f);
    [SerializeField] private Vector2 waveTextStartPos;
    [SerializeField] private Vector2 waveTextTargetPos;

    protected float speed = 5f;
    RectTransform lineTop;
    RectTransform lineBottom;
    RectTransform waveText;
    void Awake()
    {
        lineTop = transform.Find("Line Top").GetComponent<RectTransform>();
        lineBottom = transform.Find("Line Bottom").GetComponent<RectTransform>();
        waveText = transform.Find("Wave Text").GetComponent<RectTransform>();

        lineTop.localPosition = lineTopStartPosition;
        lineBottom.localPosition = lineBottomStartPosition;
        waveText.localScale = waveTextStartScale;
        
    }

    void OnEnable()
    {
        StartCoroutine(LineMoveCoroutine(lineTop, lineTopTargetPosition, lineTopStartPosition));
        StartCoroutine(LineMoveCoroutine(lineBottom, lineBottomTargetPosition, lineBottomStartPosition));
        StartCoroutine(TextScaleCoroutine(waveText, waveTextTargetScale, waveTextStartScale));
    }

    private void OnDisable()
    {
        lineTop.localPosition = lineTopStartPosition;
        lineBottom.localPosition = lineBottomStartPosition;
        waveText.localScale = waveTextStartScale;
    }
    
    IEnumerator LineMoveCoroutine(RectTransform rect, Vector2 targetPosition, Vector2 startPosition)
    {
        yield return StartCoroutine(UIMoveCoroutine(rect, targetPosition));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(UIMoveCoroutine(rect, startPosition));
    }
    
    IEnumerator TextScaleCoroutine(RectTransform rect, Vector2 targetScale, Vector2 startScale)
    {
        yield return StartCoroutine(UIScaleCoroutine(rect, targetScale));
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(UIScaleCoroutine(rect, startScale));
    }

    IEnumerator UIMoveCoroutine(RectTransform rect, Vector2 position)
    {
        float t = 0f;
        Vector2 localPosition = rect.localPosition;
        while (t < 1f)
        { 
                t += Time.deltaTime * speed;
                rect.localPosition = Vector2.Lerp(localPosition, position, t);
                yield return null;
        }
    }
    
    IEnumerator UIScaleCoroutine(RectTransform rect, Vector2 scale)
    {
        float t = 0f;
        Vector2 localScale = rect.localScale;

        while (t < 1f)
        {
                t += Time.deltaTime * speed;
                rect.localScale = Vector2.Lerp(localScale, scale, t);
                yield return null;
        }
    }
    
}
