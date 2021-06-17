using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour
{
    // Prefabs
    public GameObject Tile_Blue_Prefab;
    public GameObject Tile_Pink_Prefab;
    public GameObject Wall_Blue_Prefab;
    public GameObject Wall_Pink_Prefab;
    public GameObject Door_Blue_Prefab;
    public GameObject Door_Pink_Prefab;
    // LevelRoot
    public GameObject LevelMap;
    public GameObject Blue_LevelMap;
    public GameObject Pink_LevelMap;

    public GameObject Player_Blue;
    public GameObject Player_Pink;

    LevelData levelData;
    GridData gridData;
    int levelWidth = 12;
    int levelHeight = 6;

    // Level Tiles 0 = hole, 1 = floor, 2,3,4..9 = Wall height, 10 = Door, ?128 = player
    int[,] levelTiles;
    Vector2Int playerPos = Vector2Int.one;// j,i
    Vector2Int doorPos = Vector2Int.one;// j,i


    void Start()
    {
        levelTiles = new int[levelWidth, levelHeight];
    }


    void Update()
    {

    }


    public void InitLevel()
    {
        gridData = LevelDB.GetRandomGridData(levelWidth, levelHeight);
        levelTiles = gridData.tiles;
    }


    public void CreateLevel()
    {
        CreateBlueLevel();
        CreatePinkLevel();
        Player_Blue.transform.position = new Vector3(0, 0.2f, 0);
        Player_Pink.transform.position = new Vector3(1, 0.2f, 1);
    }


    public void CreateBlueLevel()
    {
        Vector3 offset = new Vector3(-0.5f, 0, 0.5f);
        Vector3 origin = new Vector3(0, 0, 0);

        Blue_LevelMap.transform.position = Vector3.zero;
        foreach (Transform child in Blue_LevelMap.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < levelTiles.GetLength(0); i++)
        {
            for (int j = 0; j < levelTiles.GetLength(1); j++)
            {
                // player
                if (levelTiles[i, j] == 128)
                {
                    Player_Blue.transform.position = new Vector3(i, 0.2f, j);
                    Player_Blue.transform.parent = Blue_LevelMap.transform;
                    playerPos.x = i;
                    playerPos.y = j;
                }
                // door
                else if (levelTiles[i, j] == 10)
                {
                    GameObject curObj = GameObject.Instantiate(Door_Blue_Prefab);
                    curObj.transform.position = new Vector3(i, 0.2f, j);
                    curObj.transform.parent = Blue_LevelMap.transform;
                    doorPos.x = i;
                    doorPos.y = j;
                }
                else
                {
                    if (levelTiles[i, j] >= 3)
                    {
                        GameObject curObj = GameObject.Instantiate(Wall_Blue_Prefab);
                        curObj.transform.position = new Vector3(i, 1.2f, j);
                        curObj.transform.parent = Blue_LevelMap.transform;
                    }
                    if (levelTiles[i, j] >= 2)
                    {
                        GameObject curObj = GameObject.Instantiate(Wall_Blue_Prefab);
                        curObj.transform.position = new Vector3(i, 0.2f, j);
                        curObj.transform.parent = Blue_LevelMap.transform;
                    }
                }
                if (levelTiles[i, j] >= 1)
                {
                    GameObject curObj = GameObject.Instantiate(Tile_Blue_Prefab);
                    curObj.transform.position = new Vector3(i, 0, j);
                    curObj.transform.parent = Blue_LevelMap.transform;
                }
                if (levelTiles[i, j] == 0)
                {
                    GameObject curObj = GameObject.Instantiate(Tile_Pink_Prefab);
                    curObj.transform.position = new Vector3(i, 0, j);
                    curObj.transform.parent = Blue_LevelMap.transform;
                }
            }
        }
        //Blue_LevelMap.transform.position = new Vector3(-5.5f, -0.2f, -5.5f);
        Blue_LevelMap.transform.position = new Vector3(-5f, -0.2f, -5f);
        Blue_LevelMap.transform.parent = LevelMap.transform;
    }


    public void CreatePinkLevel()
    {
        Vector3 offset = new Vector3(-0.5f, 0, 0.5f);
        Vector3 origin = new Vector3(0, 0, 0);

        Pink_LevelMap.transform.position = Vector3.zero;
        foreach (Transform child in Pink_LevelMap.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < levelTiles.GetLength(0); i++)
        {
            for (int j = 0; j < levelTiles.GetLength(1); j++)
            {
                // player
                if (levelTiles[i, j] == 128)
                {
                    Player_Pink.transform.position = new Vector3(i, 0.2f, j);
                    Player_Pink.transform.parent = Pink_LevelMap.transform;
                    playerPos.x = i;
                    playerPos.y = j;
                }
                // door
                else if (levelTiles[i, j] == 10)
                {
                    GameObject curObj = GameObject.Instantiate(Door_Pink_Prefab);
                    curObj.transform.position = new Vector3(i, 0.2f, j);
                    curObj.transform.parent = Pink_LevelMap.transform;
                    doorPos.x = i;
                    doorPos.y = j;
                }
                else
                {
                    if (levelTiles[i, j] >= 3)
                    {
                        GameObject curObj = GameObject.Instantiate(Wall_Pink_Prefab);
                        curObj.transform.position = new Vector3(i, 1.2f, j);
                        curObj.transform.parent = Pink_LevelMap.transform;
                    }
                    if (levelTiles[i, j] >= 2)
                    {
                        GameObject curObj = GameObject.Instantiate(Wall_Pink_Prefab);
                        curObj.transform.position = new Vector3(i, 0.2f, j);
                        curObj.transform.parent = Pink_LevelMap.transform;
                    }
                }
                if (levelTiles[i, j] >= 1)
                {
                    GameObject curObj = GameObject.Instantiate(Tile_Pink_Prefab);
                    curObj.transform.position = new Vector3(i, 0, j);
                    curObj.transform.parent = Pink_LevelMap.transform;
                }
                if (levelTiles[i, j] == 0)
                {
                    GameObject curObj = GameObject.Instantiate(Tile_Blue_Prefab);
                    curObj.transform.position = new Vector3(i, 0, j);
                    curObj.transform.parent = Pink_LevelMap.transform;
                }
            }
        }
        //Pink_LevelMap.transform.position = new Vector3(5.5f, -0.2f, 5.5f);
        Pink_LevelMap.transform.position = new Vector3(6f, -0.2f, 6f);
        Pink_LevelMap.transform.Rotate(Vector3.up, 180);
        Pink_LevelMap.transform.parent = LevelMap.transform;
    }


    public void LoadLevel()
    {
        InitLevel();
        CreateLevel();
    }


    public void LoadNextLevel()
    {
        gridData = LevelDB.GetRandomGridData(levelWidth, levelHeight);
        levelTiles = gridData.tiles;

        Debug.Log(levelTiles.GetLength(0));
        Debug.Log(levelTiles.GetLength(1));
        Debug.Log(levelTiles.Length);

        LoadLevel();
    }


}

