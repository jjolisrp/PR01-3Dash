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
            Debug.Log("Desactivando muro de: " + transform.name);
        }
        else if(!canPassWall)
        {
            objectiveWall.SetActive(true);
            Debug.Log("Activando muro de: " + transform.name);
        }

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
