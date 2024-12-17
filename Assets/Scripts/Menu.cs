using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject CreditsMenu;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("Level_00_Tutorial", LoadSceneMode.Single);
    }

    public void Credits()
    {
        CreditsMenu.SetActive(true);
        StartMenu.SetActive(false);
    }

    public void ExitCredits()
    {
        StartMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void doExitGame() {
        Application.Quit();
    }
}
