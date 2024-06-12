using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDPuzzleMoldInteraction : MonoBehaviour
{
    [SerializeField] GameObject _HUDPuzleMold;
    public SliderDecrease sliderDecrease; // Referencia al script SliderDecrease
    [SerializeField] GameObject ceramicaAnimation;
    [SerializeField] GameObject Character;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disparar evento
            InteractOn();
             // Activar la bandera isActive en SliderDecrease
            sliderDecrease.isActive = true;
            ceramicaAnimation.SetActive(true);
            Character.SetActive(false);

        }
    }
      private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disparar evento
            InteractOff();
            // Desactivar la bandera isActive en SliderDecrease
            sliderDecrease.isActive = false;
            ceramicaAnimation.SetActive(false);
            Character.SetActive(true);

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