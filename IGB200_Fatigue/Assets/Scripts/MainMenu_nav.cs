using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_nav : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Starting Game (Default: scene (2))");
        SceneManager.LoadScene(2);
    }

    public void OpeningHelp()
    {
        Debug.Log("Opening Help menu ...");
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game ...");
        Application.Quit();
    }

}
