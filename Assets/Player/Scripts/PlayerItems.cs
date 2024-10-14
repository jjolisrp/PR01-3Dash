using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] InputActionReference nitroKey;
    [SerializeField] Image fuelBar;
    [SerializeField] Image nitroBar;

    public float fuelRefill;
    public float nitroRefill;
    public float fuelWaste;
    public float nitroWaste;
    public float fuelQuantity;
    public float nitroQuantity;

    float timerFuelWasting;

    private void OnEnable()
    {
        nitroKey.action.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckLimits();

        fuelBar.fillAmount = fuelQuantity / 100f;
        nitroBar.fillAmount = nitroQuantity / 100f;

        timerFuelWasting += Time.deltaTime;

        if(timerFuelWasting > 3)
        {
            timerFuelWasting = 0;

            FuelWasting();
        }

        if(nitroKey.action.phase == InputActionPhase.Performed)
        {
            if(nitroQuantity > 0)
            {
                NitroWasting();
            }
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
        nitroQuantity += nitroRefill;
    }

    void FuelWasting()
    {
        fuelQuantity -= fuelWaste;
    }

    void NitroWasting()
    {
        nitroQuantity -= nitroWaste;
    }

    void CheckLimits()
    {
        if (fuelQuantity > 100)
        {
            fuelQuantity = 100;
        }

        if (nitroQuantity > 100)
        {
            nitroQuantity = 100;
        }

        if (nitroQuantity < 0)
        {
            nitroQuantity = 0;
        }
    }

    private void OnDisable()
    {
        nitroKey.action.Disable();
    }
}
