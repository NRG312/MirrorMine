using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSceneForMusic : MonoBehaviour
{
    public void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            AudioManager.instance.PlaySounds("CaveSounds");
        }
        if (level == 2)
        {
            AudioManager.instance.PlaySounds("CaveSounds");
        }
        if (level == 3)
        {
            AudioManager.instance.PlaySounds("CaveSounds");
        }
        if (level == 4)
        {
            AudioManager.instance.PlaySounds("TavernSounds");
        }
    }
    /*void Update()
    {
        if (SceneManager.GetSceneByName("TestLevelKrystian").isLoaded ||
            SceneManager.GetSceneByName("Level 1").isLoaded ||
            SceneManager.GetSceneByName("Level 2").isLoaded ||
            SceneManager.GetSceneByName("Level 3").isLoaded)
        {
            AudioManager.instance.PlaySounds("CaveSounds");         //wymysl cos innego
            //MusicManager.instance.StopSounds("TavernSounds");
        }
        if (SceneManager.GetSceneByName("Pub").isLoaded)
        {
            AudioManager.instance.StopSounds("CaveSounds");
            AudioManager.instance.PlaySounds("TavernSounds");
        }
        if (SceneManager.GetSceneByName("Main Menu").isLoaded)
        {
            AudioManager.instance.StopSounds("CaveSounds");
            AudioManager.instance.StopSounds("TavernSounds");
        }
    }*/
}
