///-----------------------------------------------------------------------------
///
/// GameMgr
/// 
/// Main game manager
///
///-----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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

    GameTimer gameTimer;

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
        HUDScripts.MoveAction += OnMoveAction;
        HUDScripts.ReverseAction += OnReverse;
        HUDScripts.NextLevelEvent += OnNextLevel;
    }


    private void OnDisable()
    {
        PlayerController.OnMoveAction -= OnMoveAction;
        HUDScripts.MoveAction -= OnMoveAction;
        HUDScripts.ReverseAction -= OnReverse;
        HUDScripts.NextLevelEvent -= OnNextLevel;
    }


    void Start()
    {
        Random.InitState(128);
        gameState = GameStates.InGame;
        GlobalData.OnInit();
        levelMgr.LoadLevel();
        gameTimer = new GameTimer();
        playerBlue = Player_Blue_Obj.GetComponent<Player>();
        playerPink = Player_Pink_Obj.GetComponent<Player>();
    }


    void Update()
    {
        GlobalData.timePlayed += Time.deltaTime;
        gameTimer.Update();
    }


    public void OnNextLevel()
    {
        commandSequnce.Clear();
        positionStore.Clear();
        levelMgr.LoadNextLevel();
        levelMgr.SaveLevel();
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
        //Debug.Log("OnMove :" + direction);
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
        // Debug.Log("OnUndoAction :" + direction);
        playerBlue.OnMoveAction(direction);
        playerPink.OnMoveAction(-direction);
    }


    bool IsValidMove(Vector3 direction)
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(playerBlue.transform.position + (Vector3.up / 2), direction, out raycastHit, 0.8f))
        {
            if (raycastHit.collider.CompareTag("Door"))
            {
                OnGameOver();
            }
            Debug.Log(raycastHit.collider.name);
            Debug.DrawRay(playerBlue.transform.position, direction);
            return false;
        }
        return true;
    }


    void OnGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }


}

