using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    [HideInInspector]
    public bool CollisionWithPlayer;
    public Item item;
    void Update()
    {
        if (CollisionWithPlayer == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Audio
                AudioManager.instance.PlaySounds("PickUpItem");

                UIManager.instance.DisableInteractionE();
                EQFunction.instance.AddItemToEQ(item);
                CollisionWithPlayer = false;
                Destroy(gameObject);
            }
        }
    }
}
