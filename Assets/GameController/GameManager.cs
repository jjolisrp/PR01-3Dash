using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text attemptText;

    bool isGamePaused;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();//mas adelante esto estará en el boton de jugar del menú
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
        attemptText.text = $"Attempt {playerController.deathCount}";
    }

    void GamePause()
    {

    }

    public void RestartLevel()
    {

    }

    void StartGame(/*Level*/)
    {
        attemptText.text = $"Attempt {1}";
    }
}
