///-----------------------------------------------------------------------------
///
/// HUDScripts
/// 
/// Modular Hud as prefab with text + buttons
///
///-----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class HUDScripts : MonoBehaviour
{
    public delegate void OnMove(Vector3 moveDir);
    public static event OnMove MoveAction;
    public delegate void OnReverse();
    public static event OnReverse ReverseAction;
    public static event OnReverse NextLevelEvent;

    // score
    public TMP_Text scoreText;

    void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = "Moves : 0 Time : 0 Seconds";
        }
    }


    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = "Moves : " + GlobalData.moves + " Time : " + (int)GlobalData.timePlayed + " Seconds";
        }
    }


    // UI
    public void OnPauseButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void OnRestartButton()
    {
        SceneManager.LoadScene("InGame");
    }


    public void OnMoveBtn(int dir)
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
        Raise_OnMoveAction(moveDir);
    }


    public void OnReverseBtn()
    {
        Raise_OnReverseAction();
    }


    public void OnNextLevelBtn()
    {
        Raise_NextLevelEvent();
    }


    // Events
    void Raise_OnMoveAction(Vector3 moveDir)
    {
        if (MoveAction != null)
            MoveAction(moveDir);
    }


    void Raise_OnReverseAction()
    {
        if (ReverseAction != null)
            ReverseAction();
    }


    void Raise_NextLevelEvent()
    {
        if (NextLevelEvent != null)
            NextLevelEvent();
    }


}

