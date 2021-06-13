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


    public static LevelData GetLevel()
    {
        LevelData levelData = new LevelData();

        int randomVal = Random.Range(0, 5);

        levelData.levelTiles = new int[,]
{
                { 1, 1, 1, 1, 1, 1 },
                { 1, 128, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 10, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
};

        if (randomVal == 0)
        {
            levelData.levelTiles = new int[,]
            {
                { 1, 1, 1, 1, 1, 1 },
                { 1, 128, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 10, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
            };
        }
        if (randomVal == 1)
        {
            levelData.levelTiles = new int[,]
            {
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 128, 1},
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 10, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
            };
        }

        if (randomVal == 2)
        {
            levelData.levelTiles = new int[,]
            {
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 128, 1},
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 2, 1, 1 },
                { 1, 1, 1, 2, 1, 1},
                { 1, 1, 1, 2, 1, 1},
                { 1, 1, 1, 2, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 10, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
            };
        }

        if (randomVal == 3)
        {
            levelData.levelTiles = new int[,]
            {
                { 1, 1, 1, 2, 2, 2 },
                { 1, 1, 1, 1, 128, 1},
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 10, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
            };
        }
        if (randomVal == 4)
        {
            levelData.levelTiles = new int[,]
            {
                { 2, 2, 2, 2, 2, 2 },
                { 1, 1, 1, 1, 128, 1},
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1 },
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1, 2},
                { 1, 10, 1, 1, 1, 2 },
                { 1, 1, 1, 1, 1, 2 },
            };
        }
        return levelData;
    }
}
