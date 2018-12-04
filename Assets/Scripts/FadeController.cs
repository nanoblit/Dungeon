using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public float FadeTime = 1f;
    private CanvasGroup _fadeGroup;

    private void Awake()
    {
        _fadeGroup = GetComponent<CanvasGroup>();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        _fadeGroup.alpha = 1;
        while (_fadeGroup.alpha > 0)
        {
            _fadeGroup.alpha -= Time.deltaTime / FadeTime;
            yield return null;
        }
        yield return null;
    }

    private IEnumerator FadeOutCoroutine()
    {
        _fadeGroup.alpha = 0;
        while (_fadeGroup.alpha < 1)
        {
            _fadeGroup.alpha += Time.deltaTime / FadeTime;
            yield return null;
        }
        yield return null;
    }
}
