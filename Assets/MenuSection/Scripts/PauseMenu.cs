using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] InputActionReference escape;
    [SerializeField] Canvas optionCanvas;

    Button resume;
    Button restart;
    Button options;
    Button mainMenu;

    CanvasGroup canvasGroupPause;
    CanvasGroup canvasGroupOptions;

    public delegate void OnPauseStateChanging();
    public static event OnPauseStateChanging PauseMenuStateChanging;

    [Header("Debug")]
    public bool pauseMenuIsActive;

    private void OnEnable()
    {
        escape.action.Enable();

        escape.action.performed += OpenAndClosePauseMenu;
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuIsActive = false;

        canvasGroupOptions = optionCanvas.GetComponent<CanvasGroup>();
        canvasGroupOptions.alpha = 0f;
        canvasGroupOptions.interactable = false;
        canvasGroupOptions.blocksRaycasts = false;

        canvasGroupPause = transform.GetComponent<CanvasGroup>();
        canvasGroupPause.alpha = 0f;
        canvasGroupPause.interactable = false;
        canvasGroupPause.blocksRaycasts = false;

        resume = transform.GetChild(1).GetComponent<Button>();
        restart = transform.GetChild(2).GetComponent<Button>();
        options = transform.GetChild(3).GetComponent<Button>();
        mainMenu = transform.GetChild(4).GetComponent<Button>();

        resume.onClick.AddListener(HidePauseMenu);
        restart.onClick.AddListener(RestartLevel);
        options.onClick.AddListener(OpenAndCloseOptions);
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

        if(PauseMenuStateChanging != null)
        {
            PauseMenuStateChanging.Invoke();
        }
    }

    void ShowPauseMenu()
    {
        canvasGroupPause.alpha = 1f;
        canvasGroupPause.interactable = true;
        canvasGroupPause.blocksRaycasts = true;
        Time.timeScale = 0f;
        pauseMenuIsActive = true;
    }

    void HidePauseMenu()
    {
        canvasGroupPause.alpha = 0f;
        canvasGroupPause.interactable = false;
        canvasGroupPause.blocksRaycasts = false;
        Time.timeScale = 1f;
        pauseMenuIsActive = false;
    }

    public void OpenAndCloseOptions()
    {
        if (canvasGroupPause.alpha == 1f)
        {
            canvasGroupPause.alpha = 0f;
            canvasGroupPause.interactable = false;
            canvasGroupPause.blocksRaycasts = false;

            canvasGroupOptions.alpha = 1f;
            canvasGroupOptions.interactable = true;
            canvasGroupOptions.blocksRaycasts = true;
        }
        else
        {
            canvasGroupPause.alpha = 1f;
            canvasGroupPause.interactable = true;
            canvasGroupPause.blocksRaycasts = true;

            canvasGroupOptions.alpha = 0f;
            canvasGroupOptions.interactable = false;
            canvasGroupOptions.blocksRaycasts = false;
        }
    }

    void RestartLevel()
    {
        Time.timeScale = 1f;
        gameManager.RestartLevel();
    }

    void GoToMainMenu()
    {
        Time.timeScale = 1f;
        gameManager.FinishGame();
    }

    private void OnDisable()
    {
        escape.action.Disable();

        escape.action.performed -= OpenAndClosePauseMenu;
    }
}
