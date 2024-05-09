using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class changeCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cameraToChange;
    public string collisionTag = "Mesa";  
    public int defaultPriority = 10;  

    private void onTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(collisionTag))
        {
            Debug.Log("COLISIONES");
            cameraToChange.Priority = 20;  
        }
    }

    private void onTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(collisionTag))
        {
            cameraToChange.Priority = defaultPriority; 
        }
    }
}