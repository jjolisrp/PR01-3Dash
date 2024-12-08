using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using Unity.VisualScripting;

public class AutoSavedSlider_ForBrightness : AutoSavedSlider
{
    [SerializeField] Volume volume;

    ColorAdjustments colorAdjustments;
    float minValue = -2.0f;
    float maxValue = 2.0f;

    float brightness = 0f;

    protected override void InternalValueChanged(float newValue)
    {
        brightness = newValue;

        if(volume.profile.TryGet(out colorAdjustments)) 
        {
            colorAdjustments.postExposure.value = Mathf.Lerp(minValue, maxValue, brightness);
        }
        else
        {
            Debug.Log("No se encontro el color adjustment");
        }
    }
}
