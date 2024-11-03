using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class AutoSaveSlider_ForContrast : AutoSavedSlider
{
    [SerializeField] Volume volume;

    ColorAdjustments colorAdjustments;
    float minValue = -40.0f;
    float maxValue = 40.0f;

    protected override void InternalValueChanged(float newValue)
    {
        if(volume.profile.TryGet(out colorAdjustments))
        {
            colorAdjustments.contrast.value = Mathf.Lerp(minValue, maxValue, newValue);
        }
        else
        {
            Debug.Log("No se encontro el color adjustment");
        }
    }
}
