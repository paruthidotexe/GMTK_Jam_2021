using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameMgr : MonoBehaviour
{
    public GameObject Player_Blue_Obj;
    public GameObject Player_Pink_Obj;

    Player playerBlue;
    Player playerPink;

    public LevelMgr levelMgr;

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
        levelMgr.LoadLevel();
        scoreText.text = "Moves : 0 Time : 0 Seconds";
        playerBlue = Player_Blue_Obj.GetComponent<Player>();
        playerPink = Player_Pink_Obj.GetComponent<Player>();
    }


    void Update()
    {
        GlobalData.timePlayed += Time.deltaTime;
        //if (playerPos == doorPos)
        //{
        //    OnGameOver();
        //}
        scoreText.text = "Moves : " + GlobalData.moves + " Time : " + (int)GlobalData.timePlayed + " Seconds";
    }


    // UI
    public void OnPauseButton()
    {
        SceneManager.LoadScene("MainMenu");
        //OnGameOver();
    }


    public void OnRestartButton()
    {
        SceneManager.LoadScene("InGame");
        //OnGameOver();
    }


    public void OnNextLevel()
    {
        levelMgr.LoadNextLevel();
    }


    public void OnMoveAction(Vector3 direction)
    {
        Debug.Log("OnMove :" + direction);
        if (IsValidMove(direction))
        {
            GlobalData.moves++;
            playerPos.x += (int)direction.x;
            playerPos.y += (int)direction.z;
            playerBlue.OnMoveAction(direction);
            playerPink.OnMoveAction(-direction);
            //Player_Blue_Obj.transform.position += direction;
            //Player_Pink_Obj.transform.position += -direction;
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
