using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Functions : MonoBehaviour
{
    public void Resume()
    {
        Player.instance.BlockMovement = false;
    }
    public void MainMenu()
    {
        AudioManager.instance.isLevel1 = false;
        AudioManager.instance.isLevel2 = false;
        AudioManager.instance.isPub = false;
        AudioManager.instance.isMenu = true;
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
