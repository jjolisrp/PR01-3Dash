using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransitionFader : MonoBehaviour
{
    [SerializeField] CanvasGroup currentFade;

    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        currentFade.DOFade(2f, 1f).SetEase(Ease.Linear);
    }

    public void FadeOut()
    {
        currentFade.DOFade(0f, 1f).SetEase(Ease.Linear);
    }
}
