using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementPolicia : ElementsManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyEffect(PlayerController player)
    {
        player.KillPlayer();
    }
}
