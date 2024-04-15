using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InteractableObject : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform player; 

    private void Update()
    { 
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < 1f && virtualCamera != null)
        {
            // Reposiciona Cinemachine entre player y this.object
            //virtualCamera.MoveTo(transform.position);          
        }
    }
}