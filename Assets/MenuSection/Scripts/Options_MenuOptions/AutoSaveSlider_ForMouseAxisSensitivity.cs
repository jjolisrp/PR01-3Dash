using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AutoSaveSlider_ForMouseAxisSensitivity : AutoSavedSlider
{
    [SerializeField] CinemachineFreeLook freeLookCamera;

    float multMin = 0.1f;
    float multMax = 7.0f;

    protected override void InternalValueChanged(float newValue)
    {
        float interpolation = Mathf.Lerp(multMin, multMax, newValue);

        freeLookCamera.m_XAxis.m_MaxSpeed = interpolation;
        freeLookCamera.m_YAxis.m_MaxSpeed = interpolation;
    }
}
