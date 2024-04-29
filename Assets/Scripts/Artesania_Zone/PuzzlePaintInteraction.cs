using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePaintInteraction : MonoBehaviour
{
    [SerializeField] GameObject _CameraPuzlePaint;
    [SerializeField] GameObject _HUDPuzlePaint;

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
        _CameraPuzlePaint.SetActive(true);
        _HUDPuzlePaint.SetActive(true);

    }

     private void InteractOff()
    {
        Debug.Log("Fuera del objeto");
        _CameraPuzlePaint.SetActive(false);
        _HUDPuzlePaint.SetActive(false);
    }
}