using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalData
{
    public static float timePlayed = 0;// seconds
    public static int timePlayedInt = 0;// seconds
    public static int moves = 0;
    public static int score = 0;

    public GlobalData()
    {
    }


    public static void OnInit()
    {
        timePlayed = 0;
        timePlayedInt = 0;
        moves = 0;
        score = 0;
    }


    public static string GetTimeAsString()
    {
        return "00:00";
    }

}


