using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameMgr : MonoBehaviour
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

    // Level Tiles 0 = hole, 1 = floor, 2,3,4..9 = Wall height, 10 = Door, ?128 = player
    int[,] levelTiles = new int[12, 6];
    Vector2Int playerPos = Vector2Int.one;// j,i
    Vector2Int doorPos = Vector2Int.one;// j,i

    public TMP_Text scoreText;

    public enum GameStates
    {
        None = 0,
        MainMenu,
        Loading,
        InGame,
        Pause,
        GameOver
    };
    GameStates gameState;
    LevelData levelData;

    private void OnEnable()
    {
        PlayerController.OnMoveAction += OnMoveAction;
    }

    private void OnDisable()
    {
        PlayerController.OnMoveAction -= OnMoveAction;
    }

    void Start()
    {
        gameState = GameStates.InGame;
        GlobalData.OnInit();
        InitLevel();
        CreateLevel();
        scoreText.text = "Moves : 0 Time : 0 Seconds";
    }


    void Update()
    {
        GlobalData.timePlayed += Time.deltaTime;
        if (playerPos == doorPos)
        {
            OnGameOver();
        }
        scoreText.text = "Moves : " + GlobalData.moves + " Time : " + (int)GlobalData.timePlayed + " Seconds";
    }


    void CreateLevel()
    {
        Vector3 offset = new Vector3(-0.5f, 0, 0.5f);
        Vector3 origin = new Vector3(0, 0, 0);

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 6; j++)
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
        Blue_LevelMap.transform.position = new Vector3(-5, -0.2f, -5);
        Blue_LevelMap.transform.parent = LevelMap.transform;

        CreatePinkLevel();
    }

    void CreatePinkLevel()
    {
        Vector3 offset = new Vector3(-0.5f, 0, 0.5f);
        Vector3 origin = new Vector3(0, 0, 0);

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 6; j++)
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
        Pink_LevelMap.transform.position = new Vector3(6, -0.2f, 6);
        Pink_LevelMap.transform.Rotate(Vector3.up, 180);
        Pink_LevelMap.transform.parent = LevelMap.transform;
    }

    void InitLevel()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                levelTiles[i, j] = Random.Range(0, 2);
            }
        }

        levelData = GlobalData.GetLevel();

        levelTiles = levelData.levelTiles;
    }

    // UI
    public void OnMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        //OnGameOver();
    }



    public void OnMoveAction(Vector3 direction)
    {
        Debug.Log("OnMove :" + direction);
        if (IsValidMove(direction))
        {
            GlobalData.moves++;
            playerPos.x += (int)direction.x;
            playerPos.y += (int)direction.y;
            Player_Blue.transform.position += direction;
            Player_Pink.transform.position += -direction;
            Debug.Log(playerPos + " vs " + doorPos);
        }
    }

    bool IsValidMove(Vector3 direction)
    {
        return true;
    }

    void OnGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void OnMoveUIAction(int dir)
    {
        Vector3 moveDir = Vector3.zero;
        if (dir == 1)
        {
            moveDir.x = -1;
            moveDir.y = 0;
            moveDir.z = 0;
        }
        if (dir == 2)
        {
            moveDir.x = 1;
            moveDir.y = 0;
            moveDir.z = 0;
        }
        if (dir == 3)
        {
            moveDir.x = 0;
            moveDir.y = 0;
            moveDir.z = 1;
        }
        if (dir == 4)
        {
            moveDir.x = 0;
            moveDir.y = 0;
            moveDir.z = -1;
        }
        OnMoveAction(moveDir);
    }

}
