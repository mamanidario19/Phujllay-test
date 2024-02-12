using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public abstract class EstadoZorro 
{
    protected Zorrito zorrito;
    protected Transform player;
    protected NavMeshAgent navMeshAgent;

    public void Inicializar(Zorrito zorrito, Transform player, NavMeshAgent navMeshAgent)
    {
        this.zorrito = zorrito;
        this.player = player;
        this.navMeshAgent = navMeshAgent;
    }

    // Metodo para actualizar el estado en cada frames
    public abstract void Actualizar();
}