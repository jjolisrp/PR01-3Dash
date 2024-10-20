using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementObjective : ElementsManager
{
    [SerializeField] ElementObjective secondStar;
    bool playerTouch;

    // Start is called before the first frame update
    void Start()
    {
        playerTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ApplyEffect(PlayerController player)
    {
        playerTouch = true;
        if(secondStar.playerTouch == false)
        {
            player.KillPlayer();
        }
    }
}
