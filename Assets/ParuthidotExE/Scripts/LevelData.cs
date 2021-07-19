///-----------------------------------------------------------------------------
///
/// LevelData
/// 
/// Data across scenes / levels
///
///-----------------------------------------------------------------------------

using UnityEngine;


public class LevelData
{
    // Level Tiles 0 = hole, 1 = floor, 2,3,4..9 = Wall height, 10 = Door, ?128 = player
    public int[,] tiles;
    public int levelId;
    public string levelName = "";
    public int time = 120;//seconds

    public LevelData()
    {
        tiles = new int[12, 6];
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                tiles[i, j] = Random.Range(0, 2);
            }
        }
    }


    void Update()
    {

    }

}




