using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : Singleton<TimeController>
{
    [SerializeField, Range(0f, 1f)]
    float bulletTimeScale = 0.1f;

    private float delautFixedTime;

    private float t;

    private Coroutine cor;

    protected override void Awake()
    {
        base.Awake();
        this.delautFixedTime = Time.fixedDeltaTime;
    }

    public void TimeBullet()
    {
        /*Time.timeScale = this.bulletTimeScale;
        StartCoroutine(SlowOutTimeScale(1f));*/
        if (this.cor != null)
        {
            StopAllCoroutines();
        }

        this.cor = StartCoroutine(nameof(SlowInAndOutScale));
    }

    IEnumerator SlowInAndOutScale()
    {
        yield return StartCoroutine(SlowInTimeScale(1f));
        StartCoroutine(SlowOutTimeScale(1f));
    }

    IEnumerator SlowInTimeScale(float duration)
    {
        t = 0;
        while (t<1f)
        {
            t += Time.unscaledDeltaTime / duration;
            Time.timeScale = Mathf.Lerp(1f, this.bulletTimeScale, t);
            Time.fixedDeltaTime = this.delautFixedTime * Time.timeScale;
            yield return null;
        }
    }

    IEnumerator SlowOutTimeScale(float duration)
    {
        t = 0;
        while (t<1f)
        {
            t += Time.unscaledDeltaTime / duration;
            Time.timeScale = Mathf.Lerp(this.bulletTimeScale, 1f, t);
            Time.fixedDeltaTime = this.delautFixedTime * Time.timeScale;
            yield return null;
        }
    }
}
