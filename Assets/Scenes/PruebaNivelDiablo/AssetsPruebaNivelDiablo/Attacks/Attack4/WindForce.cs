using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindForce : MonoBehaviour
{
    //public DetectedCoverage detectedCoverage;
    public List<DetectedCoverage> detectedCoverages = new List<DetectedCoverage>();
    public bool isWindActive = false;
    private float windStrength = 5f;
    // Start is called before the first frame update
    void Start()
    {
        // Busca todos los objetos DetectedCoverage en la escena
        DetectedCoverage[] allDetectedCoverages = FindObjectsOfType<DetectedCoverage>();
        detectedCoverages.AddRange(allDetectedCoverages);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // Comprueba si el objeto en el área del viento tiene un CharacterController
        CharacterController characterController = other.GetComponent<CharacterController>();
        // Comprueba si el objeto en el área del viento tiene un Rigidbody
        if (characterController != null && isWindActive)
        {
            foreach (var coverage in detectedCoverages)
            {
                if (coverage.isCovering == true)
                {
                    // El jugador está cubierto, no aplicar el viento
                    return;
                }
            }
            // Mueve el CharacterController en la dirección opuesta a la del viento
            characterController.Move(-transform.forward * windStrength * Time.deltaTime);
        }
    }

    // Método para activar el viento
    public void ActivateWind()
    {
        isWindActive = true;
    }

    // Método para desactivar el viento
    public void DeactivateWind()
    {
        isWindActive = false;
    }
}
