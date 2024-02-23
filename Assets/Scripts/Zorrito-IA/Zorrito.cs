using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zorrito : MonoBehaviour
{
    [SerializeField] private Transform player;
    private EstadoZorro estadoActual;  // Estado actual del zorrito
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Collider zonaProhibida;
    //public bool siguiendo = true;
    private bool Siguiendo { get; set; } = true; //Propiedad auto-implementada privada
    private bool enIdle = false;
    [SerializeField] private ZorritoAnim zorritoAnim;

    public ZorritoAnim GetZorritoAnim()
    {
        return zorritoAnim;
    }
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        zorritoAnim = GetComponent<ZorritoAnim>();
        estadoActual = new EstadoSeguimiento();
        estadoActual.Inicializar(this, player, navMeshAgent);
    }

    private void Update()
    {

        if (Siguiendo) // Verifica si el zorrito esta siguiendo antes de actualizar su estado
        {
            estadoActual.Actualizar(); // Actualiza el estado actual del zorrito en cada frame

        }

        if (Siguiendo && zonaProhibida.bounds.Contains(transform.position)) // Verifica si el zorrito esta dentro de la zona prohibida
        {
            navMeshAgent.enabled = false; // Desactiva el componente NavMeshAgent para que el zorrito no se mueva
        }
        else
        {
            navMeshAgent.enabled = true; // Activa el componente NavMeshAgent si el zorrito esta fuera de la zona

        }
    }

    // Metodo para cambiar el estado del zorrito
    public void CambiarEstado(EstadoZorro nuevoEstado)
    {
        estadoActual = nuevoEstado;
        estadoActual.Inicializar(this, player, navMeshAgent);
        // Logica p/animacion y la espera
        StartCoroutine(EsperarCambiarEstado());
    }
    private IEnumerator EsperarCambiarEstado()
    {
        if (estadoActual is EstadoSeguimiento) // Aanimacion segun el estado actual
        {
            zorritoAnim.Walk();
        }
        else if (estadoActual is EstadoBusqueda)
        {
            zorritoAnim.Search();
        }
        yield return new WaitForSeconds(1f); //Pausa el metodo
        zorritoAnim.IsNotSearch(); // Detiene la animacion de búsqueda
        enIdle = false; // Restablece si estaba en estado de Idle
    }

    public void Interactuar()
    {
        if (estadoActual is EstadoSeguimiento) // Verifica si el estado actual es igual a ES. Y realiza la accion correspondiente
        {
            CambiarEstado(new EstadoBusqueda());
        }
        else if (estadoActual is EstadoLocalizacion)
        {
            Debug.Log("Zorrito: ¡Encontre algo!");
        }
    }

    public void Seguir()
    {
        if (estadoActual is EstadoBusqueda)
        {
            // Detener la busqueda y transicionar al estado actual
            CambiarEstado(new EstadoSeguimiento());
            zorritoAnim.Idle(); 
            return;
        }
        Siguiendo = !Siguiendo; // Cambia el estado de seguimiento del zorrito

        if (Siguiendo)
        {
            navMeshAgent.isStopped = false; // Si esta siguiendo, habilita el nav y cambia al estado de seguimiento

            TransicionarAEstadoSeguimiento();

        }
        else
        {
            navMeshAgent.isStopped = true; // Si no, para el nav y realiza acciones..
            Debug.Log("Te espero!");
            enIdle = true; // Establece que el zorrito esta en estado de Idle
            zorritoAnim.Idle();
        }
    }

    public void TransicionarAEstadoSeguimiento()
    {
        CambiarEstado(new EstadoSeguimiento());
        if (!enIdle)
        {
            zorritoAnim.Walk();
        }
        else
        {
            enIdle = false; // Resetea la variable enIdle
        }
    }

}