using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class NavigateToAfterTimeOrPress : MonoBehaviour
{
    [SerializeField] InputActionReference skip;
    [SerializeField] CanvasGroup imageCanvasGroup;
    [SerializeField] float waitTime;
    [SerializeField] string nextSceneName;
    bool sceneIsCalled;


    void Awake()
    {
        Invoke("FadeIn", waitTime);
    }

    private void OnEnable()
    {
        skip.action.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneIsCalled = false;
        imageCanvasGroup.DOFade(0f, 1f).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void Update()
    {
        if(skip.action.IsPressed())
        {
            FadeIn();
        }
    }

    void FadeIn()
    {
        imageCanvasGroup.DOFade(2f, 1f).SetEase(Ease.Linear).OnComplete(NavigateToNextScreen);
    }

    void NavigateToNextScreen()
    {
        if(!sceneIsCalled)
        {
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        }
    }

    private void OnDisable()
    {
        skip.action.Disable();
    }
}
