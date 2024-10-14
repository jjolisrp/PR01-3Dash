using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void ApplyEffect(PlayerController player)
    {
        //Que efecto aplica al player
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if(player != null)
            {
                ApplyEffect(other.GetComponent<PlayerController>());
            }
        }
    }
}
