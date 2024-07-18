using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDPuzzleMoldInteraction : MonoBehaviour
{
    [SerializeField] GameObject _HUDPuzleMold;
    public SliderDecrease sliderDecrease; // Referencia al script SliderDecrease
    [SerializeField] GameObject ceramicaAnimation;
    [SerializeField] GameObject Character;

    private bool isPlayerInside = false; // Variable para rastrear si el jugador está dentro del área de interacción

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true; // Marcar que el jugador está dentro del área
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false; // Marcar que el jugador ha salido del área
            InteractOff(); // Asegurarse de desactivar la interacción cuando el jugador salga del área
        }
    }

    private void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            InteractOn();
        }
    }

    private void InteractOn()
    {
        Debug.Log("Interactuando con el objeto");
        _HUDPuzleMold.SetActive(true);
        sliderDecrease.isActive = true;
        sliderDecrease.InitializeSlider(); // Poner el slider en el centro al activar la interacción
        ceramicaAnimation.SetActive(true);
        Character.SetActive(false);
    }

    public void InteractOff()
    {
        Debug.Log("Fuera del objeto");
        _HUDPuzleMold.SetActive(false);
        sliderDecrease.isActive = false;
        ceramicaAnimation.SetActive(false);
        Character.SetActive(true);
    }
}