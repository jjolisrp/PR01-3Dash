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
    [Header("References")]
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text attemptText;
    [SerializeField] GameObject itemGroup;

    //string sceneName;
    //Scene scene;
    bool isGamePaused;

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
        //SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }

    public void RetryLevel()
    {
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
}
