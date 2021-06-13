using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverScreen : MonoBehaviour
{
    void Start()
    {
        
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
