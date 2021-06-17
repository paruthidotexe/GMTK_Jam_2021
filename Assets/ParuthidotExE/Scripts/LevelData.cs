using System.Collections;
using System.Collections.Generic;
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


public class TileData
{
    public TileData()
    {

    }
}


public class GridData
{
    public int width = 8;
    public int height = 8;
    public int length = 8;
    public float cellSize = 1.0f;

    public int gridAxis = 2;// 1 =  XY; 2 = XZ 
    public int[,] tiles;

    public Vector3 orgin = Vector3.zero;


    public GridData()
    {
        InitGrid();
    }


    public GridData(int newWidth, int newHeight)
    {
        width = newWidth;
        height = newHeight;
        if (gridAxis == 2)
            length = newHeight;
        InitGrid();
    }


    public void InitGrid()
    {
        if (gridAxis == 2)
            height = length;

        tiles = new int[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                tiles[i, j] = 0;
            }
        }
        Debug.Log(GetGridAsString());
    }


    public string GetGridAsString()
    {
        string gridStr = "";
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                gridStr += tiles[i, j];
            }
            gridStr += "\n";
        }
        Debug.Log(gridStr);
        return gridStr;
    }


    public void SetTileValue(int x, int y, int value)
    {
        tiles[x, y] = value;
    }


    public int GetTileValue(int x, int y)
    {
        return tiles[x, y];
    }


    public void SetTileValue(Vector3 worldPos, int value)
    {

    }


    public int GetTileValue(Vector3 worldPos)
    {
        return 0;
    }


    public Vector3 GetWorldPos()
    {
        return Vector3.zero;
    }


}


