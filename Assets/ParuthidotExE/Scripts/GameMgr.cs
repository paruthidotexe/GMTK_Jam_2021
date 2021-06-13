using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMgr : MonoBehaviour
{
    // Prefabs
    public GameObject Tile_Blue_Prefab;
    public GameObject Tile_Pink_Prefab;
    public GameObject Wall_Blue_Prefab;
    public GameObject Wall_Pink_Prefab;
    // LevelRoot
    public GameObject LevelMap;

    public GameObject Player_Blue;
    public GameObject Player_Pink;

    // Level Tiles 0 = hole, 1 = floor, 2,3,4..9 = Wall height, 10 = Door, ?128 = player
    int[,] levelTiles = new int[12,6];
    Vector2Int playerPos = Vector2Int.one;// j,i

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
        
        InitLevel();
        CreateLevel();
    }


    void Update()
    {

    }


    void CreateLevel()
    {
        Vector3 offset = new Vector3(-0.5f, 0, 0.5f);
        Vector3 origin = new Vector3(0, 0, 0);

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (levelTiles[i, j] >= 3)
                {
                    GameObject curObj = GameObject.Instantiate(Wall_Blue_Prefab);
                    curObj.transform.position = new Vector3(i, 1.2f, j);
                    curObj.transform.parent = LevelMap.transform;
                }
                if (levelTiles[i, j] >= 2)
                {
                    GameObject curObj = GameObject.Instantiate(Wall_Blue_Prefab);
                    curObj.transform.position = new Vector3(i, 0.2f, j);
                    curObj.transform.parent = LevelMap.transform;
                }
                if (levelTiles[i, j] >= 1)
                {
                    GameObject curObj = GameObject.Instantiate(Tile_Blue_Prefab);
                    curObj.transform.position = new Vector3(i, 0, j);
                    curObj.transform.parent = LevelMap.transform;
                }
                if (levelTiles[i, j] == 0)
                {
                    GameObject curObj = GameObject.Instantiate(Tile_Pink_Prefab);
                    curObj.transform.position = new Vector3(i, 0, j);
                    curObj.transform.parent = LevelMap.transform;
                }
            }
        }
    }

    void InitLevel()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                levelTiles[i, j] = Random.Range(0,4);
            }
        }
    }

    // UI
    public void OnMenuButton()
    {
        SceneManager.LoadScene("GameOver");
    }


    public void OnMoveAction(Vector3 direction)
    {
        Debug.Log("OnMove :" + direction);
        if(IsValidMove(direction))
        {
            Player_Blue.transform.position += direction;
            Player_Pink.transform.position += -direction;
        }
    }

    bool IsValidMove(Vector3 direction)
    {
        return true;
    }


}
