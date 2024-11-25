using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerItems playerItems;
    [SerializeField] TMP_Text attemptText;
    [SerializeField] GameObject itemGroup;

    public delegate void OnGamePaused();
    public static event OnGamePaused gameIsPaused;

    public delegate void OnGameDespause();
    public static event OnGameDespause gameDespause;

    Scene scene;

    bool isGamePaused;

    private void OnEnable()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        InGame();
    }

    public void FinishGame()
    {
        Time.timeScale = 1f;
        LoadingScene.instance.LoadScene("MainMenu", true);
    }

    void InGame()
    {
        attemptText.text = $"Attempt- {playerController.deathCount}";
    }

    public void GamePause()
    {
        Time.timeScale = 0f;
        gameIsPaused.Invoke();
    }

    public void GameDespause()
    {
        Time.timeScale = 1f;
        gameDespause.Invoke();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        LoadingScene.instance.LoadScene(SceneManager.GetActiveScene().name, true);
    }

    public void RetryLevel()
    {
        for (int i = 0; i < itemGroup.transform.childCount; i++)
        {
            itemGroup.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    void StartGame()
    {
        attemptText.text = $"Attempt {1}";

        itemGroup.SetActive(true);
    }

    private void OnDisable()
    {

    }
}
