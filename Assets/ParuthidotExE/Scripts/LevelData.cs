using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData 
{
    // Level Tiles 0 = hole, 1 = floor, 2,3,4..9 = Wall height, 10 = Door, ?128 = player
    public int[,] levelTiles;

    public LevelData()
    {
        levelTiles = new int[12, 6];
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                levelTiles[i, j] = Random.Range(0, 2);
            }
        }
    }


    void Update()
    {
        
    }

}


public class TileData 
{






    public TileData()
    {

    }
}
