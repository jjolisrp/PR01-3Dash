using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public float fuelRefill;
    public float nitroRefill;
    public float fuelWaste;
    public float nitroWaste;

    float timerFuelWasting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefillFuel()
    {
        Debug.Log("Rellenando gasolina");
    }

    public void RefillNitro()
    {
        Debug.Log("Rellenando nitro");
    }

    void FuelWasting()
    {

    }

    void NitroWasting()
    {

    }
}
