using System;
using System.Collections;
using UnityEngine;

public enum TransitionType
{
    Fade,
    SlideFromRight,
    SlideFromLeft,
    Scale,
    None
}

[RequireComponent(typeof(AudioSource))]
public class UIScreenAnimator : MonoBehaviour
{
    [SerializeField] private TransitionType openTransition = TransitionType.Fade;
    [SerializeField] private TransitionType closeTransition = TransitionType.Fade;
    [SerializeField] private float duration = 0.3f;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;

    public bool IsAnimating { get; private set; }

    private AudioSource _audioSource;
    private Coroutine _currentCoroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayOpen(CanvasGroup cg, Action onComplete)
    {
        Cancel();
        _currentCoroutine = StartCoroutine(AnimateRoutine(cg, openTransition, true, onComplete, openSound));
    }

    public void PlayClose(CanvasGroup cg, Action onComplete)
    {
        Cancel();
        _currentCoroutine = StartCoroutine(AnimateRoutine(cg, closeTransition, false, onComplete, closeSound));
    }

    public void Cancel()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = null;
        }

        IsAnimating = false;
    }

    private IEnumerator AnimateRoutine(CanvasGroup cg, TransitionType transition, bool isOpen, Action onComplete, AudioClip sound)
    {
        IsAnimating = true;

        if (cg == null)
        {
            Debug.LogWarning("UIScreenAnimator: CanvasGroup is null, skipping animation.");
            IsAnimating = false;
            onComplete?.Invoke();
            yield break;
        }

        PlaySound(sound);

        if (transition == TransitionType.None)
        {
            SetFinalState(cg, isOpen);
            IsAnimating = false;
            onComplete?.Invoke();
            yield break;
        }

        yield return StartCoroutine(ExecuteTransition(cg, transition, isOpen));

        IsAnimating = false;
        onComplete?.Invoke();
    }

    private IEnumerator ExecuteTransition(CanvasGroup cg, TransitionType transition, bool isOpen)
    {
        switch (transition)
        {
            case TransitionType.Fade:
                yield return StartCoroutine(FadeRoutine(cg, isOpen));
                break;
            case TransitionType.SlideFromRight:
                yield return StartCoroutine(SlideRoutine(cg, isOpen, slideInFromRight: true));
                break;
            case TransitionType.SlideFromLeft:
                yield return StartCoroutine(SlideRoutine(cg, isOpen, slideInFromRight: false));
                break;
            case TransitionType.Scale:
                yield return StartCoroutine(ScaleRoutine(cg, isOpen));
                break;
        }
    }

    private IEnumerator FadeRoutine(CanvasGroup cg, bool isOpen)
    {
        float startAlpha = isOpen ? 0f : 1f;
        float endAlpha = isOpen ? 1f : 0f;

        cg.alpha = startAlpha;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            cg.alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            yield return null;
        }

        cg.alpha = endAlpha;
    }

    private IEnumerator SlideRoutine(CanvasGroup cg, bool isOpen, bool slideInFromRight)
    {
        RectTransform rectTransform = cg.transform as RectTransform;
        if (rectTransform == null)
        {
            Debug.LogWarning("UIScreenAnimator: CanvasGroup has no RectTransform, cannot slide. Falling back to Fade.");
            yield return StartCoroutine(FadeRoutine(cg, isOpen));
            yield break;
        }

        float width = rectTransform.rect.width;
        float startX, endX;

        if (isOpen)
        {
            startX = slideInFromRight ? width : -width;
            endX = 0f;
        }
        else
        {
            startX = 0f;
            endX = slideInFromRight ? width : -width;
        }

        Vector2 pos = rectTransform.anchoredPosition;
        pos.x = startX;
        rectTransform.anchoredPosition = pos;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            pos = rectTransform.anchoredPosition;
            pos.x = Mathf.Lerp(startX, endX, t);
            rectTransform.anchoredPosition = pos;

            yield return null;
        }

        pos = rectTransform.anchoredPosition;
        pos.x = endX;
        rectTransform.anchoredPosition = pos;
    }

    private IEnumerator ScaleRoutine(CanvasGroup cg, bool isOpen)
    {
        Vector3 startScale = isOpen ? Vector3.zero : Vector3.one;
        Vector3 endScale = isOpen ? Vector3.one : Vector3.zero;

        cg.transform.localScale = startScale;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            cg.transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }

        cg.transform.localScale = endScale;
    }

    private void SetFinalState(CanvasGroup cg, bool isOpen)
    {
        cg.alpha = isOpen ? 1f : 0f;
        cg.interactable = isOpen;
        cg.blocksRaycasts = isOpen;

        Transform t = cg.transform;
        t.localScale = isOpen ? Vector3.one : Vector3.zero;

        RectTransform rectTransform = t as RectTransform;
        if (rectTransform != null)
        {
            Vector2 pos = rectTransform.anchoredPosition;
            pos.x = 0f;
            rectTransform.anchoredPosition = pos;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (_audioSource != null && clip != null)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}
