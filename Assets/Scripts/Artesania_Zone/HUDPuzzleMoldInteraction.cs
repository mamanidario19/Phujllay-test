using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDPuzzleMoldInteraction : MonoBehaviour
{
    [SerializeField] GameObject _HUDPuzleMold;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disparar evento
            InteractOn();
        }
    }
      private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disparar evento
            InteractOff();
        }
    }

    private void InteractOn()
    {
        Debug.Log("Interactuando con el objeto");
        _HUDPuzleMold.SetActive(true);

    }

     private void InteractOff()
    {
        Debug.Log("Fuera del objeto");
        _HUDPuzleMold.SetActive(false);
    }
}