using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    // switches scene from MainMenu to Rules
    public void switchToRules()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // switches scene from Rules to MainMenu
    public void rulesToMainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    
    // switches scene from MainMenu to Settings
    public void switchToSettings() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // switches scene from Settings to MainMenu
    public void settingsToMainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    // switches scene from MainMenu to Lobby
    public void switchToLobby() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    // switches scene from Rules to Lobby
    public void rulesToLobby() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // switches scene from Lobby to MainMenu
    public void lobbyToMainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
