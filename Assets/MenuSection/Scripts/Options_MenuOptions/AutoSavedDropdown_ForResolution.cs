using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSavedDropdown_ForResolution : AutoSavedDropdown
{
    [SerializeField] AutoSavedCheckBox_ForFullScreen fullScreen;

    protected override void InternalValueChanged(int newValue)
    {
        if(newValue == 0)
        {
            Screen.SetResolution(1920, 1080, fullScreen.isFullScreen);
        }
        else if(newValue == 1)
        {
            Screen.SetResolution(1080, 720, fullScreen.isFullScreen);
        }
        else if(newValue == 2)
        {
            Screen.SetResolution(800, 500, fullScreen.isFullScreen);
        }
    }
}
