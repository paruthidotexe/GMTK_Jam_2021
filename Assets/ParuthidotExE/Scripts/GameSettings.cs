using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings
{
    public static int maxFPS = 60;
    public static int qualitySetting = 1;// 1 = max
    public static int screenWidth = 1280;
    public static int screenHeight = 720;

    public static bool isFullScreen = true;
    public static bool isVsync = true;
    public static bool isPostProcessing = true;

    public GameSettings()
    {

    }


}

//
// 2do
// input map
// screen resolution by percentage ?
// screen resolution by aspect ratios ?
//