using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSavedCheckBox : MonoBehaviour
{
    [SerializeField] string playerPrefsKey;
    int defaultValue = 0;
    Toggle toggle;

    private void Awake()
    {
        toggle = transform.GetComponent<Toggle>();

        toggle.onValueChanged.AddListener(OnToggleValueChanged);

        toggle.isOn = PlayerPrefs.GetInt(playerPrefsKey, defaultValue) == 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        InternalValueChanged(toggle.isOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    protected virtual void InternalValueChanged(bool newValue)
    {

    }

    void OnToggleValueChanged(bool isOn)
    {
        InternalValueChanged(isOn);

        PlayerPrefs.SetInt(playerPrefsKey, isOn ? 1 : 0); //Operador ternario
        //Si isOn es true, el resultado será 1
        //Si isOn es false, el resultado será 0

        PlayerPrefs.Save();
    }
}
