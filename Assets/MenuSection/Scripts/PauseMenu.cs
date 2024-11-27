using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] InputActionReference escape;

    Button resume;
    Button restart;
    Button mainMenu;

    CanvasGroup canvasGroupPause;

    [Header("Debug")]
    public bool pauseMenuIsActive;

    private void OnEnable()
    {
        escape.action.Enable();

        escape.action.performed += OpenAndClosePauseMenu;

        FinalLevel.PlayerFinishedLevel += OnPlayerFinishedLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuIsActive = false;

        canvasGroupPause = transform.GetComponent<CanvasGroup>();

        resume = transform.GetChild(1).GetComponent<Button>();
        restart = transform.GetChild(2).GetComponent<Button>();
        mainMenu = transform.GetChild(4).GetComponent<Button>();

        resume.onClick.AddListener(HidePauseMenu);
        restart.onClick.AddListener(RestartLevel);
        mainMenu.onClick.AddListener(GoToMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OpenAndClosePauseMenu(InputAction.CallbackContext ctx)
    {
        if (canvasGroupPause.alpha == 0f && !pauseMenuIsActive)
        {
            ShowPauseMenu();
        }
        else if (canvasGroupPause.alpha == 1f && pauseMenuIsActive)
        {
            HidePauseMenu();
        }
    }

    void ShowPauseMenu()
    {
        GameManager.instance.GamePause();
        canvasGroupPause.alpha = 1f;
        canvasGroupPause.interactable = true;
        canvasGroupPause.blocksRaycasts = true;
        pauseMenuIsActive = true;
    }

    void HidePauseMenu()
    {
        GameManager.instance.GameDespause();
        canvasGroupPause.alpha = 0f;
        canvasGroupPause.interactable = false;
        canvasGroupPause.blocksRaycasts = false;
        pauseMenuIsActive = false;
    }

    void RestartLevel()
    {
        GameManager.instance.RestartLevel();
    }

    void GoToMainMenu()
    {
        GameManager.instance.FinishGame();
    }

    void OnPlayerFinishedLevel()
    {
        escape.action.Disable();
    }

    private void OnDisable()
    {
        escape.action.Disable();

        escape.action.performed -= OpenAndClosePauseMenu;

        FinalLevel.PlayerFinishedLevel -= OnPlayerFinishedLevel;
    }
}
