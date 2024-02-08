using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EstadoLocalizacion : EstadoZorro
{
    public override void Actualizar()
    {
        // animacion o sonido
        // Implementa la logica específica para este estado
        Debug.Log("Zorrito: ¡Encontré algo!");
        // Cambia el estado del zorrito a 'EstadoSeguimiento'
        zorrito.TransicionarAEstadoSeguimiento();
    }
}
