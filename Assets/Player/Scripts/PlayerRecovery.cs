using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRecovery : MonoBehaviour
{
    
    [SerializeField] PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
