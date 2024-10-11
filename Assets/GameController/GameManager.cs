using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]


    bool isGamePaused;

    [Header("Referencias")]
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();//mas adelante esto estará en el boton de jugar del menú
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FinishGame()
    {

    }

    void GamePause()
    {

    }

    void StartGame(/*Level*/)
    {

    }
}
