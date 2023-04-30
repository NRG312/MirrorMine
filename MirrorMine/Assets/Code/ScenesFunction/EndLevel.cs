using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Pub");
            AudioManager.instance.isPub = true;
            AudioManager.instance.isLevel1 = false;
            AudioManager.instance.isLevel2 = false;
            AudioManager.instance.CheckingScenesForMusic();
        }
    }
}
