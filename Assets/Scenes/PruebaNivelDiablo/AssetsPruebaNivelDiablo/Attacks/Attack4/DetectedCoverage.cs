using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectedCoverage : MonoBehaviour
{
    public bool isCovering = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto en el área del viento tiene un CharacterController
        CharacterController characterController = other.GetComponent<CharacterController>();
        // Comprueba si el objeto en el área del viento tiene un Rigidbody
        if (characterController)
        {
            isCovering = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Comprueba si el objeto en el área del viento tiene un CharacterController
        CharacterController characterController = other.GetComponent<CharacterController>();
        // Comprueba si el objeto en el área del viento tiene un Rigidbody
        if (characterController)
        {
            isCovering = false;
        }
    }
}