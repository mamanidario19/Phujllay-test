using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mancha : MonoBehaviour, IInteractuable
{
    [SerializeField] private int puntos = 1;

    public void Interactuar(PuntajeJugador jugador)
    {
        jugador.AgregarPuntaje(puntos);

        Destroy(this.gameObject);
    }
}
