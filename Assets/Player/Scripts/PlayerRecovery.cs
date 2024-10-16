using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRecovery : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerController player;

    [SerializeField] InputActionReference recoverKey;

    private void OnEnable()
    {
        recoverKey.action.Enable();
        recoverKey.action.performed += OnPerformed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPerformed(InputAction.CallbackContext ctx)
    {
        player.KillPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if(player != null)
            {
                player.KillPlayer();
            }
        }
    }

    private void OnDisable()
    {
        recoverKey.action.Disable();
        recoverKey.action.performed -= OnPerformed;

    }
}
