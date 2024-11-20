using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerItems : MonoBehaviour
{
    [Header("References")]
    [SerializeField] PlayerController playerController;

    [Header("Input Actions")]
    [SerializeField] InputActionReference nitroKey;

    [Header("UI Elements")]
    [SerializeField] Image fuelBar;
    [SerializeField] Image nitroBar;

    [Header("Variables")]
    public float fuelRefill;
    public float nitroRefill;

    public float fuelWaste;
    public float nitroWaste;

    public float fuelQuantity;
    public float nitroQuantity;

    float speedWithNitro;
    float startFuelQuantity;
    float startNitroQuantity;

    bool isGamePaused;

    private void OnEnable()
    {
        nitroKey.action.Enable();
        nitroKey.action.canceled += ReturnPlayerSpeed;

        PlayerController.PlayerRestarted += RestartValuesOnPlayerKilled;
        GameManager.gameIsPaused += OnPause;
    }

    // Start is called before the first frame update
    void Start()
    {
        speedWithNitro = playerController.speed * 2f; //Deben ser multiplos de 2

        startFuelQuantity = fuelQuantity;
        startNitroQuantity = nitroQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        if(fuelQuantity < 0)
        {
            playerController.KillPlayer();
        }
    }

    private void FixedUpdate()
    {
        if (!isGamePaused)
        {
            CheckLimits();

            fuelBar.fillAmount = fuelQuantity / 100f;
            nitroBar.fillAmount = nitroQuantity / 100f;

            FuelWasting();

            if (nitroKey.action.phase == InputActionPhase.Performed)
            {
                if (nitroQuantity > 0)
                {
                    NitroWasting();
                }
                else
                {
                    playerController.speed = speedWithNitro / 2f;
                }
            }
        }
    }

    public void RefillFuel()
    {
        //Debug.Log("Rellenando gasolina");
        fuelQuantity += fuelRefill;
    }

    public void RefillNitro()
    {
        //Debug.Log("Rellenando nitro");
        nitroQuantity += nitroRefill;
    }

    void FuelWasting()
    {
        fuelQuantity -= fuelWaste;
    }

    void NitroWasting()
    {
        nitroQuantity -= nitroWaste;

        playerController.speed = speedWithNitro;
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

    public void OnPause()
    {
        isGamePaused = !isGamePaused;
    }

    void RestartValuesOnPlayerKilled()
    {
        fuelQuantity = startFuelQuantity;
        nitroQuantity = startNitroQuantity;
    }

    void ReturnPlayerSpeed(InputAction.CallbackContext ctx)
    {
        playerController.speed = speedWithNitro / 2f;
    }

    private void OnDisable()
    {
        nitroKey.action.Disable();
        nitroKey.action.canceled += ReturnPlayerSpeed;

        PlayerController.PlayerRestarted -= RestartValuesOnPlayerKilled;
        GameManager.gameIsPaused -= OnPause;
    }
}
