using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraConstantRotation : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freelookCamera;
    [SerializeField] float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        freelookCamera.m_XAxis.Value += rotationSpeed * Time.deltaTime;
    }
}
