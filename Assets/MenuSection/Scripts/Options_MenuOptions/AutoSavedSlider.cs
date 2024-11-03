using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AutoSavedSlider : MonoBehaviour
{
    [SerializeField] string playerPrefKey = "SliderValue";
    float defaultValue = 1;
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();

        slider.onValueChanged.AddListener(OnSliderValueChanged);

        slider.value = PlayerPrefs.GetFloat(playerPrefKey, defaultValue);
    }

    // Start is called before the first frame update
    void Start()
    {
        InternalValueChanged(slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void InternalValueChanged(float newValue)
    {

    }

    void OnSliderValueChanged(float value)
    {
        InternalValueChanged(value);

        PlayerPrefs.SetFloat(playerPrefKey, value);

        PlayerPrefs.Save();
    }
}
