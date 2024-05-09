using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    public bool isWindActive = false;
    private float windStrength = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // Comprueba si el objeto en el �rea del viento tiene un CharacterController
        CharacterController characterController = other.GetComponent<CharacterController>();
        // Comprueba si el objeto en el �rea del viento tiene un Rigidbody
        if (characterController != null && isWindActive)
        {
            // Mueve el CharacterController en la direcci�n opuesta a la del viento
            characterController.Move(-transform.forward * windStrength * Time.deltaTime);
        }
    }

    // M�todo para activar el viento
    public void ActivateWind()
    {
        isWindActive = true;
    }

    // M�todo para desactivar el viento
    public void DeactivateWind()
    {
        isWindActive = false;
    }
}
