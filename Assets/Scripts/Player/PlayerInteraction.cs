/*Script para evaluar si hay objetos Interactuables al rededor*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Rango para la interaccion del jugador
    public float interactionRange = 5f;

    // Capa de objetos interactuables
    public LayerMask interactableLayer;

    void Awake()
    {
        // Se inicializa la capa de objetos interactuables
        interactableLayer = LayerMask.GetMask("Default");
    }

    void Update()
    {
        // Detecta la tecla E para interactuar
        if (Input.GetKey(KeyCode.E))
        {
            TryInteract();
        }
    }
    // Intento de interaccion con objetos cercanos
    void TryInteract()
    {
        // Raycast hacia adelante para detectar objetos interactuables
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange, interactableLayer))
        {
            // Llamaal metodo de interaccion del objeto interactuable
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
}
