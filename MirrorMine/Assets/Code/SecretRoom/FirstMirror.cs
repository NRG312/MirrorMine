using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMirror : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<MirrorFunction>().teleportingToMir2 = true;
        }
    }
}
