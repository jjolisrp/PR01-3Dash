using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementObjective : ElementsManager
{
    [SerializeField] ElementObjective secondStar;
    [SerializeField] GameObject objectiveWall;
    
    bool playerTouch;
    bool canPassWall;

    private void OnEnable()
    {
        PlayerController.PlayerRestarted += RestartWall;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTouch = false;
        canPassWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(canPassWall)
        {
            objectiveWall.SetActive(false);
        }
        else if(!canPassWall)
        {
            objectiveWall.SetActive(true);
        }

        //Comprueba que los dos objetivos esten siendo tocados a la vez
        if (secondStar.playerTouch == true)
        {
            canPassWall = true;
        }

    }

    void RestartWall()
    {
        canPassWall = false;
        playerTouch = false;
    }

    protected override void ApplyEffect(PlayerController player)
    {
        playerTouch = true;
    }

    private void OnDisable()
    {
        PlayerController.PlayerRestarted -= RestartWall;
    }
}
