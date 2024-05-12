using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeJugador : MonoBehaviour
{
    [SerializeField] private int puntaje = 0;
    [SerializeField] private TextMeshProUGUI textoPuntaje;
    [SerializeField] private float tiempoPresionado = 0f;
    [SerializeField] private float tiempoMaximo = 1f;

    [SerializeField] private GameObject canvasBarra;
    [SerializeField] private Image barraCarga;

    private IInteractuable interactuable;
    private bool accion;

    private void Start()
    {
        //textoPuntaje = GameObject.Find("Canvas/TPuntaje").GetComponent<TextMeshProUGUI>();

        textoPuntaje.text = "Puntaje: " + puntaje;

        accion = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E) && accion)
        {
            tiempoPresionado += Time.deltaTime;

            canvasBarra.SetActive(true);            

            ActualizarBarraCarga();

            if (tiempoPresionado >= tiempoMaximo)
            {
                interactuable.Interactuar(this);

                accion = false;

                //textoPuntaje.text = "Puntaje: " + puntaje;

                tiempoPresionado = 0f;
            }
        }
        else
        {
            tiempoPresionado = 0f;

            canvasBarra.SetActive(false);
        }
    }

    public void AgregarPuntaje(int puntos)
    {
        puntaje += puntos;
    }

    private void ActualizarBarraCarga()
    {
        float proporcionLlenado = Mathf.Clamp(tiempoPresionado / tiempoMaximo, 0f, 1f);

        barraCarga.fillAmount = proporcionLlenado;
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
