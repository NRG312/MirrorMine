using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    [HideInInspector]
    public bool CollisionWithPlayer;
    
    void Update()
    {
        if (CollisionWithPlayer == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UIManager.instance.DisableInteractionE();

                CollisionWithPlayer = false;
            }
        }
    }
}
