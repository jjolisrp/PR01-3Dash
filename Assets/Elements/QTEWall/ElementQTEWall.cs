using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementQTEWall : ElementsManager
{
    protected override void ApplyEffect(PlayerController player)
    {
        player.KillPlayer();
    }
}
