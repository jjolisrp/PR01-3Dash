using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AutoSavedSlider_ForAudio : AutoSavedSlider
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] string exposedParameter;

    protected override void InternalValueChanged(float newValue)
    {
        newValue = LinearToDecibel(newValue);

        mixer.SetFloat(exposedParameter, newValue);
    }

    private float LinearToDecibel(float linear)
    {
        float dB;

        if (linear != 0)
        {
            dB = 20.0f * Mathf.Log10(linear);
        }
        else
        {
            dB = -144.0f;
        }

        return dB;
    }
}
