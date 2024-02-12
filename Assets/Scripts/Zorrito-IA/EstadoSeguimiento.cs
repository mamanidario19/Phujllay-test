using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EstadoSeguimiento : EstadoZorro
{
    private float distanciaDeseada = 2.0f;

    public override void Actualizar()
    {
        Vector3 direccion = player.position - navMeshAgent.transform.position; // Calcula la direccion hacia el jugador
        float distanciaActual = direccion.magnitude; // Calcula la distancia actual al jugador

        if (distanciaActual > distanciaDeseada) // Si la distancia actual es mayor que la deseada, ajusta la posicion objetivo
        {
            direccion.Normalize(); // Normaliza la direccion
            Vector3 posicionObjetivo = player.position - direccion * distanciaDeseada; // Calcula la posicion objetivo con la distancia deseada
            posicionObjetivo.y = player.position.y; // Mantiene la misma altura que el jugador
            navMeshAgent.SetDestination(posicionObjetivo); // Establece la posicion objetivo
            navMeshAgent.speed = direccion.magnitude * 10.0f; // Establece la velocidad como la velocidad del jugador
            zorrito.zorritoAnim.Walk();
        }
        else
        {
            navMeshAgent.ResetPath(); // Se detiene si ya estas lo suficientemente cerca
            zorrito.zorritoAnim.Idle();
        }
    }
}