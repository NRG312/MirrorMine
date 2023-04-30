using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingFunction : MonoBehaviour
{
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 6f)
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}
