using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AutoSavedBox_ForMouseAxisInvert : AutoSavedCheckBox
{
    [SerializeField] CinemachineFreeLook freeLookCamera;
    bool inVertedverticalAxis = false;
    bool invertedHorizontalAxis = false;

    protected override void InternalValueChanged(bool newValue)
    {
        freeLookCamera.m_XAxis.m_InvertInput = newValue;
        freeLookCamera.m_YAxis.m_InvertInput = newValue;
    }
}
