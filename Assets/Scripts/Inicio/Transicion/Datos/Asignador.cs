using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asignador : MonoBehaviour
{
    [SerializeField] private Transform posicion;
    [SerializeField] private ControladorDatosJuego controlador;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            controlador.GuardarDatos(posicion);
        }
    }
}
