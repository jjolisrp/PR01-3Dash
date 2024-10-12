using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelItem : ItemsManager
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ApplyEffect(PlayerItems items)
    {
        Debug.Log("He colisionado con un fuel");

        items.RefillFuel();
    }
}
