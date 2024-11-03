using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoSavedDropdown : MonoBehaviour
{
    [SerializeField] string playerPrefsKey;
    int defaultValue = 0;
    TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        dropdown.value = PlayerPrefs.GetInt(playerPrefsKey, defaultValue);
    }

    // Update is called once per frame
    void Update()
    {
        InternalValueChanged(dropdown.value);
    }

    protected virtual void InternalValueChanged(int newValue)
    {

    }

    void OnDropdownValueChanged(int value)
    {
        InternalValueChanged(value);

        PlayerPrefs.SetInt(playerPrefsKey, value);

        PlayerPrefs.Save();
    }
}
