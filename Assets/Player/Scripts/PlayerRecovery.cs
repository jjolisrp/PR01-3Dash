using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRecovery : MonoBehaviour
{
    [SerializeField] InputActionReference recoverKey;
    [SerializeField] PlayerController player;

    private void OnEnable()
    {
        recoverKey.action.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(recoverKey.action.phase == InputActionPhase.Performed)
        {
            player.KillPlayer();
        }
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
    }
}
