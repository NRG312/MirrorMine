using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondMirror : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<MirrorFunction>().teleportingToMir1 = true;
        }
    }
}
