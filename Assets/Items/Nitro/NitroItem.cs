using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroItem : ItemsManager
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
        //Debug.Log("He colisionado con un nitro");

        items.RefillNitro();
    }

    protected override void DeactivateItem()
    {
        Collider itemCollider = gameObject.GetComponent<Collider>();

        gameObject.SetActive(false);
    }
}
