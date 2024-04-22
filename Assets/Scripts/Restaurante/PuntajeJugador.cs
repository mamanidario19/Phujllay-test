using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeJugador : MonoBehaviour
{
    [SerializeField] private int puntaje = 0;
    [SerializeField] private TextMeshProUGUI textoPuntaje;

    private IInteractuable interactuable;
    private bool accion;

    private void Start()
    {
        textoPuntaje = GameObject.Find("Canvas/TPuntaje").GetComponent<TextMeshProUGUI>();

        textoPuntaje.text = "Puntaje: " + puntaje;

        accion = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && accion)
        {
            interactuable.Interactuar(this);

            accion = false;

            textoPuntaje.text = "Puntaje: " + puntaje;            
        }
    }

    public void AgregarPuntaje(int puntos)
    {
        puntaje += puntos;
    }

    private void OnTriggerEnter(Collider other)
    {
        interactuable = other.GetComponent<IInteractuable>();
        
        if (interactuable != null)
        {
            accion = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactuable = other.GetComponent<IInteractuable>();

        if (interactuable != null)
        {
            accion = false;
        }
    }
}
