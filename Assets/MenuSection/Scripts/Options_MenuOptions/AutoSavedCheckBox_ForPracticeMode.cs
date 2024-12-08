using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSavedCheckBox_ForPracticeMode : AutoSavedCheckBox
{
    [SerializeField] GameObject practiceModeManager;

    bool isInPracticeMode = false;

    protected override void InternalValueChanged(bool value)
    {
        isInPracticeMode = value;

        if(isInPracticeMode == true)
        {
            practiceModeManager.SetActive(true);
        }
        else
        {
            practiceModeManager.SetActive(false);
        }
    }

}
