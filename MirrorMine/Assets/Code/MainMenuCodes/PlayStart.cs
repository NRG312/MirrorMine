using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayStart : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
        DestroyOnEndGame.instance.destroy = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
