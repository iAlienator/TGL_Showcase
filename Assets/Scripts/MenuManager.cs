using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Menu functionality for starting the game.
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    // Menu functionality for exiting the game.
    public void Exit()
    {
        Application.Quit();
    }
}
