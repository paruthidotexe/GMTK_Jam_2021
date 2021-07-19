///-----------------------------------------------------------------------------
///
/// GameOverScreen
/// 
/// GameOverScreen UI
///
///-----------------------------------------------------------------------------

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        scoreText.text = "Moves : " + GlobalData.moves + "\nTime : " + (int)GlobalData.timePlayed + " Seconds" + "\nScore : " + (int)(GlobalData.timePlayed * 1.5);
    }


    void Update()
    {

    }


    public void OnMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void OnTryAgainButton()
    {
        SceneManager.LoadScene("InGame");
    }

}
