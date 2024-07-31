using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posicionador : MonoBehaviour
{
    [SerializeField] private ControladorDatosJuego controlador;

    private void Start()
    {
        controlador.CargarDatos();
    }
}
