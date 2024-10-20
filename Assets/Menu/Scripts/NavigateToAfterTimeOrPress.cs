using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NavigateToAfterTimeOrPress : MonoBehaviour
{
    [SerializeField] InputActionReference skip;
    [SerializeField] float waitTime;
    [SerializeField] string nextSceneName;
    bool sceneIsCalled;


    void Awake()
    {
        Invoke("NavigateToNextScreen", waitTime);
    }

    private void OnEnable()
    {
        skip.action.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneIsCalled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (skip.action.IsPressed())
        {
            NavigateToNextScreen();
        }
    }

    void NavigateToNextScreen()
    {
        if (!sceneIsCalled)
        {
            SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
        }
    }

    private void OnDisable()
    {
        skip.action.Disable();
    }
}
