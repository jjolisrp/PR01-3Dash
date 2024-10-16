using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text attemptText;
    [SerializeField] GameObject itemGroup;
    [SerializeField] InputActionReference recoverKey;

    //string sceneName;
    //Scene scene;
    bool isGamePaused;

    private void OnEnable()
    {
        recoverKey.action.Enable();
        recoverKey.action.performed += OnPerformed;
    }

    // Start is called before the first frame update
    void Start()
    {
        //scene = SceneManager.GetActiveScene();
        //sceneName = scene.name;

        StartGame(/*sceneName*/);//mas adelante esto estará en el boton de jugar del menú
    }

    // Update is called once per frame
    void Update()
    {
        InGame();
    }

    void FinishGame()
    {

    }

    void InGame()
    {
        attemptText.text = $"Attempt- {playerController.deathCount}";
    }

    void GamePause()
    {

    }

    public void RestartLevel()
    {
        
    }

    public void RetryLevel()
    {
        playerController.KillPlayer();

        for (int i = 0; i < itemGroup.transform.childCount; i++)
        {
            itemGroup.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void StartGame(/*string SceneName*/)
    {
        //SceneManager.LoadScene(SceneName, LoadSceneMode.Single);

        attemptText.text = $"Attempt {1}";

        itemGroup.SetActive(true);
    }

    void OnPerformed(InputAction.CallbackContext ctx)
    {
        Debug.Log("Dentro...");
        RetryLevel();
    }

    private void OnDisable()
    {
        recoverKey.action.Disable();
        recoverKey.action.performed -= OnPerformed;

    }
}
