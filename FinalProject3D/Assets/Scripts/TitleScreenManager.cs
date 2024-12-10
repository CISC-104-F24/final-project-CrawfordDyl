using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void StartGame()
    {
        // Load the main game scene (replace "MainGame" with your game scene's name)
        SceneManager.LoadScene("MainGame");
    }

    public void QuitGame()
    {
        // Quit the application
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}