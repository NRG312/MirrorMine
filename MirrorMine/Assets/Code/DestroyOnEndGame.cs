using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEndGame : MonoBehaviour
{
    public static DestroyOnEndGame instance;
    [HideInInspector]
    public bool destroy;
    private void Update()
    {
        instance = this;

        Destroy(GameObject.Find("Main Camera"));
        Destroy(GameObject.Find("player"));
        Destroy(GameObject.Find("Directional Light"));
        Destroy(GameObject.Find("NPC"));
        Destroy(GameObject.Find("UI"));
    }
    
}
