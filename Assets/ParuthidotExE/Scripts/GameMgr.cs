using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMgr : MonoBehaviour
{
    // Prefabs
    public GameObject Tile_Blue_Prefab;
    public GameObject Tile_Pink_Prefab;
    // LevelRoot
    public GameObject LevelMap;


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


    void Start()
    {
        gameState = GameStates.InGame;
        //CreateLevel();
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
                GameObject curObj = GameObject.Instantiate(Tile_Blue_Prefab);
                curObj.transform.position = new Vector3(i, 0, j);
                curObj.transform.parent = LevelMap.transform;
            }
        }
    }


    public void OnMenuButton()
    {
        SceneManager.LoadScene("GameOver");
    }


}
