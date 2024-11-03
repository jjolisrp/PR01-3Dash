using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementBanner : ElementsManager
{
    Collider bannerCollider;

    // Start is called before the first frame update
    void Start()
    {
        bannerCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ApplyEffect(PlayerController player)
    {
        bannerCollider.enabled = false;
        Invoke("ReactivatePortal", 0.5f);

        if(!player.isSpecialZone)
        {
            player.BannerPortalTransform();
        }
        else
        {
            player.PlayerDestransform();
        }
    }

    void ReactivatePortal()
    {
        bannerCollider.enabled = true;
    }
}
