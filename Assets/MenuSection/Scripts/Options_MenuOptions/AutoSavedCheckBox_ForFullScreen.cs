using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSavedCheckBox_ForFullScreen : AutoSavedCheckBox
{
    public bool isFullScreen = true;

    protected override void InternalValueChanged(bool newValue)
    {
        isFullScreen = newValue;

        //if (isFullScreen == false)
        //{
        //    //Debug.Log("Entrando en la A");
        //    //Screen.fullScreenMode = FullScreenMode.Windowed;
        //    Screen.fullScreen = isFullScreen;
        //}
        //else
        //{
        //    //Debug.Log("Entrando en la B");
        //    //Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        //    Screen.fullScreen = isFullScreen;
        //}

        Screen.fullScreen = isFullScreen;
    }
}
