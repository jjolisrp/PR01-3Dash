using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void ApplyEffect(PlayerItems items)
    {
        //Que fecto aplica a los items
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            PlayerItems item = other.GetComponent<PlayerItems>();

            if(item != null)
            {
                ApplyEffect(item);
            }
        }
    }

    protected virtual void DestroyItem()
    {
        //Como se destruye el item
    }
}
