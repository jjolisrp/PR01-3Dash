using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTrafficCone : ElementsManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ApplyEffect(PlayerController player)
    {
        //Debug.Log("He colisionado con un cono");

        player.KillPlayer();
    }
}
