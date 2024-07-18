using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePaintInteraction : MonoBehaviour
{
    [SerializeField] GameObject _CameraPuzzlePaint;
    [SerializeField] GameObject _HUDPuzzlePaint;

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
            InteractOffPaint(); // Asegurarse de desactivar la interacción cuando el jugador salga del área
        }
    }

    private void Update()
    {
        // Verificar si el jugador está dentro del área y presiona la tecla E
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            InteractOn();
        }
    }

    private void InteractOn()
    {
        Debug.Log("Interactuando con el objeto");
        _CameraPuzzlePaint.SetActive(true);
        _HUDPuzzlePaint.SetActive(true);
    }

    public void InteractOffPaint()
    {
        Debug.Log("Fuera del objeto");
        _CameraPuzzlePaint.SetActive(false);
        _HUDPuzzlePaint.SetActive(false);
    }
}