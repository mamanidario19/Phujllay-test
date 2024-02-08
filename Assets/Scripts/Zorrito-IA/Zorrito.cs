using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zorrito : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private EstadoZorro estadoActual;  // Estado actual del zorrito
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Collider zonaProhibida;
    

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Inicializa el estado del zorrito
        estadoActual = new EstadoSeguimiento();
        estadoActual.Inicializar(this, player, navMeshAgent);
    }

    private void Update()
    {
        // Actualiza el estado actual del zorrito en cada frame
        estadoActual.Actualizar();

        // Verifica si el zorrito esta dentro de la zona prohibida
        if (zonaProhibida.bounds.Contains(transform.position))
        {
            // Desactiva el componente NavMeshAgent para que el zorrito no se mueva
            navMeshAgent.enabled = false;
            // Lanza el evento
        }
        else
        {
            // Activa el componente NavMeshAgent si el zorrito esta fuera de la zona
            navMeshAgent.enabled = true;
        }
    }

    // Metodo para cambiar el estado del zorrito
    public void CambiarEstado(EstadoZorro nuevoEstado)
    {
        estadoActual = nuevoEstado;
        estadoActual.Inicializar(this, player, navMeshAgent);
    }

    public void Interactuar()
    {
        // Verifica si el estado actual es igual a ES. Y realiza la accion correspondiente
        if (estadoActual is EstadoSeguimiento)
        {
            CambiarEstado(new EstadoBusqueda());
            
        }
        else if (estadoActual is EstadoLocalizacion)
        {
            Debug.Log("Zorrito: ¡Encontre algo!");
        }
    }
    public void TransicionarAEstadoSeguimiento()
{
    CambiarEstado(new EstadoSeguimiento());
}
    
}