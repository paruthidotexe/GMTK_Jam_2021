using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameMgr : MonoBehaviour
{
    // player
    public GameObject Player_Blue_Obj;
    public GameObject Player_Pink_Obj;
    Player playerBlue;
    Player playerPink;

    // level
    public LevelMgr levelMgr;
    List<string> commandSequnce = new List<string>();
    List<Vector3> positionStore = new List<Vector3>();

    // UI
    public TMP_Text scoreText;

    // Game states
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

    public void OnReverse()
    {
        if (positionStore.Count <= 0)
            return;
        Vector3 newDir = positionStore[positionStore.Count - 1];
        OnUndoAction(-newDir);
        positionStore.RemoveAt(positionStore.Count - 1);
        commandSequnce.RemoveAt(commandSequnce.Count - 1);
    }


    public void OnMoveAction(Vector3 direction)
    {
        Debug.Log("OnMove :" + direction);
        if (IsValidMove(direction))
        {
            GlobalData.moves++;
            playerBlue.OnMoveAction(direction);
            playerPink.OnMoveAction(-direction);
            commandSequnce.Add(direction.ToString());
            positionStore.Add(direction);
            string commandSequnceStr = "";
            foreach (string commandStr in commandSequnce)
            {
                commandSequnceStr += " > " + commandStr;
            }
            Debug.Log(commandSequnceStr);
        }
    }


    public void OnUndoAction(Vector3 direction)
    {
        Debug.Log("OnUndoAction :" + direction);

        playerBlue.OnMoveAction(direction);
        playerPink.OnMoveAction(-direction);

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
