using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera2DChange : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera camera2D;
    [SerializeField] CinemachineVirtualCamera cameraGameplay;

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
            ToggleCameraVisibility();

            Debug.Log("Ha chocado para cambiar las camaras");
        }
    }

    void ToggleCameraVisibility()
    {
        camera2D.enabled = !camera2D.enabled;
        cameraGameplay.enabled = !cameraGameplay.enabled;
    }
}
