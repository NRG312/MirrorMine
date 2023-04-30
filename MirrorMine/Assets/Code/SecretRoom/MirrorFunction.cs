using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorFunction : MonoBehaviour
{ 
    public GameObject Mirror1;
    public GameObject Mirror2;

    [HideInInspector]public bool teleportingToMir2;
    [HideInInspector]public bool teleportingToMir1;

    public GameObject Player;

    private void Update()
    {
        float distance = Vector3.Distance(Mirror1.transform.position, Player.transform.position);
        if (distance < 1.5f)
        {
            DistanceApproaching(2f);
        }
        if (distance < 1.2f)
        {
            DistanceApproaching(4f);
        }
        if (distance < 0.9f)
        {
            DistanceApproaching(6f);
        }
        if (distance < 0.7f)
        {
            DistanceApproaching(8f);
        }

        if (teleportingToMir1 == true)
        {
            StartCoroutine(TeleportToMirror1());
        }
        if (teleportingToMir2 == true)
        {
            StartCoroutine(TeleportToMirror2());
        }
    }
    private void DistanceApproaching(float amount)
    {
        Mirror1.GetComponent<Outline>().OutlineWidth = amount;
    }

    
    public IEnumerator TeleportToMirror2()
    {
        if (teleportingToMir2 == true)
        {
            Player.gameObject.SetActive(false);
            Player.transform.position = Mirror2.transform.position + -Mirror2.transform.forward * 0.4f;
            Player.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            teleportingToMir2 = false;
            StopCoroutine(TeleportToMirror2());
        }
    }
    public IEnumerator TeleportToMirror1()
    {
        if (teleportingToMir1 == true)
        {
            Player.gameObject.SetActive(false);
            Player.transform.position = Mirror1.transform.position + -Mirror1.transform.forward * 0.4f;
            Player.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            teleportingToMir1 = false;
            StopCoroutine(TeleportToMirror1()); 
        }
    }
}
