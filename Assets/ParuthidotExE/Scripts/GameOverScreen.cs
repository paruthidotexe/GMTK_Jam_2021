using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        scoreText.text = "Moves : " + GlobalData.moves + "\n Time : " + (int)GlobalData.timePlayed + " Seconds";
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
