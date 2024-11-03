using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFader : MonoBehaviour
{
    [SerializeField] bool startsFadedOut;
    CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (startsFadedOut)
        {
            canvasGroup.alpha = 0f;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
    }

    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        canvasGroup.DOFade(1f, 0.5f).SetEase(Ease.Linear);
    }

    public void FadeOut()
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        canvasGroup.DOFade(0f, 0.5f).SetEase(Ease.Linear);
    }
}
