using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingGame : MonoBehaviour
{
    public Image mirrorMine;
    public Canvas Menu;
    public Canvas startingGame;
    private void Update()
    {
        if (mirrorMine.enabled == false)
        {
            startingGame.enabled = false;
            Menu.enabled = true;
        }
    }
}
