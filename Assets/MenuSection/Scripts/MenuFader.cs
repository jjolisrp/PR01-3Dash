using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuFader : MonoBehaviour
{
    [SerializeField] bool startsFadedOut;
    [SerializeField] GameObject startSelection;

    CanvasGroup canvasGroup;
    private EventSystem eventSystem;

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

    private void Start()
    {
        eventSystem = EventSystem.current;
    }

    public void FadeIn()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
        canvasGroup.DOFade(1f, 0.5f).SetEase(Ease.Linear);

        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(startSelection);
    }

    public void FadeOut()
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
        canvasGroup.DOFade(0f, 0.5f).SetEase(Ease.Linear);
    }
}
