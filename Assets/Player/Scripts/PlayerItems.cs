using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] Image fuelBar;

    public float fuelRefill;
    public float nitroRefill;
    public float fuelWaste;
    public float nitroWaste;
    public float fuelQuantity;
    public float nitroQuantity;

    float timerFuelWasting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fuelQuantity > 100)
        {
            fuelQuantity = 100;
        }

        fuelBar.fillAmount = fuelQuantity / 100f;

        timerFuelWasting += Time.deltaTime;

        if(timerFuelWasting > 3)
        {
            timerFuelWasting = 0;

            FuelWasting();
        }
    }

    public void RefillFuel()
    {
        Debug.Log("Rellenando gasolina");
        fuelQuantity += fuelRefill;
    }

    public void RefillNitro()
    {
        Debug.Log("Rellenando nitro");
    }

    void FuelWasting()
    {
        fuelQuantity -= fuelWaste;
    }

    void NitroWasting()
    {

    }
}
