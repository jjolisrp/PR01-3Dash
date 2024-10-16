using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text attemptText;
    [SerializeField] GameObject itemGroup;
    [SerializeField] InputActionReference recoverKey;

    [SerializeField] SceneManager scene;

    bool isGamePaused;

    private void OnEnable()
    {
        recoverKey.action.Enable();
        recoverKey.action.performed += OnPerformed;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame(scene);//mas adelante esto estar� en el boton de jugar del men�
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

        itemGroup.SetActive(true);
    }

    void StartGame(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
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
