using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private float clickScaleBounce = 0.95f;

    private Button button;
    private Vector3 originalScale;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null && UIManager.instance != null && UIManager.instance.uiAudioSource != null)
        {
            UIManager.instance.uiAudioSource.PlayOneShot(hoverSound);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // No action needed on pointer exit
    }

    private void OnClick()
    {
        if (clickSound != null && UIManager.instance != null && UIManager.instance.uiAudioSource != null)
        {
            UIManager.instance.uiAudioSource.PlayOneShot(clickSound);
        }

        StopAllCoroutines();
        StartCoroutine(ScaleBounce());
    }

    private IEnumerator ScaleBounce()
    {
        float halfDuration = 0.05f;

        // Scale down: 1 -> bounce
        float elapsed = 0f;
        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(originalScale, originalScale * clickScaleBounce, t);
            yield return null;
        }
        transform.localScale = originalScale * clickScaleBounce;

        // Scale back up: bounce -> 1
        elapsed = 0f;
        while (elapsed < halfDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / halfDuration;
            transform.localScale = Vector3.Lerp(originalScale * clickScaleBounce, originalScale, t);
            yield return null;
        }
        transform.localScale = originalScale;
    }

    private void OnDestroy()
    {
        if (button != null)
        {
            button.onClick.RemoveListener(OnClick);
        }
    }
}
