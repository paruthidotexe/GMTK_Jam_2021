///-----------------------------------------------------------------------------
///
/// MainMenu
/// 
/// MainMenu UI
///
///-----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {

    }


    public void OnPlayButton()
    {
        SceneManager.LoadScene("InGame");
    }
}
