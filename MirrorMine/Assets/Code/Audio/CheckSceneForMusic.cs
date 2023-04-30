using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSceneForMusic : MonoBehaviour
{
    public void OnLevelWasLoaded(int level)
    {
        AudioManager.instance.CheckingScenesForMusic();
    }
    
}
