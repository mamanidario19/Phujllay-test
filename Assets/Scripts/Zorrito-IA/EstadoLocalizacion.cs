using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EstadoLocalizacion : EstadoZorro
{
    public override void Actualizar()
    {
        Debug.Log("Zorrito: ¡Encontré algo!");
        // Cambia el estado del zorrito a 'EstadoSeguimiento'
        zorrito.TransicionarAEstadoSeguimiento();
    }
}
