using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EstadoSeguimiento : EstadoZorro
{
    private float distanciaDeseada = 2.0f;

    public override void Actualizar()
    {
        // Calcula la direccion hacia el jugador
        Vector3 direccion = player.position - navMeshAgent.transform.position;

        // Calcula la distancia actual al jugador
        float distanciaActual = direccion.magnitude;

        // Si la distancia actual es mayor que la deseada, ajusta la posicion objetivo
        if (distanciaActual > distanciaDeseada)
        {
            // Normaliza la direccion
            direccion.Normalize();

            // Calcula la posicion objetivo con la distancia deseada
            Vector3 posicionObjetivo = player.position - direccion * distanciaDeseada;

            // Mantiene la misma altura que el jugador
            posicionObjetivo.y = player.position.y;

            // Establece la posicion objetivo
            navMeshAgent.SetDestination(posicionObjetivo);
            
            // Establece la velocidad como la velocidad del jugador
            navMeshAgent.speed = direccion.magnitude * 4.0f; // Aumenta la velocidad
        }
        else
        {
            // Se detiene si ya estas lo suficientemente cerca
            navMeshAgent.ResetPath();
        }
    }
}