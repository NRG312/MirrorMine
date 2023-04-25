using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAtObject : MonoBehaviour
{
    public GameObject Object;
    void Update()
    {
        transform.position = Object.transform.position + new Vector3(0, -2, 0);
    }
}
