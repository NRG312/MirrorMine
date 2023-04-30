using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Image Intro1,Intro2,intro3;
    public GameObject Menu, intro;
    private int clickedSpace = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            clickedSpace++;
        }
        if (clickedSpace == 1)
        {
            Intro1.enabled = false;
            Intro2.enabled = true;
        }
        if (clickedSpace == 2)
        {
            Intro2.enabled = false;
            intro3.enabled = true;
        }
        if (clickedSpace == 3)
        {
            intro.SetActive(false);
            Menu.SetActive(true);
            clickedSpace = 0;
        }
    }
}
