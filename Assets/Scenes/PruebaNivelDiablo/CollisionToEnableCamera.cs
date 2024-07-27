using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionToEnableCamera : MonoBehaviour
{
    public bool isPlaying;
    public GameObject CameraNivelToActivate;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraNivelToActivate.SetActive(true);
        }
    }
}