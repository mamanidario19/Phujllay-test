using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DatosJuego
{
    [SerializeField] private Vector3 posicionAparicion;

    public Vector3 PosicionAparicion
    {
        get => posicionAparicion;

        set => posicionAparicion = value;
    }
}
