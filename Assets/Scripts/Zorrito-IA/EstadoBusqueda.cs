using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EstadoBusqueda : EstadoZorro
{
    private float rangoBusqueda = 15f;

    public override void Actualizar()
    {
        Collider[] espiritus = Physics.OverlapSphere(navMeshAgent.transform.position, rangoBusqueda, LayerMask.GetMask("Spirit"));

        /* foreach (var espiritu in espiritus)
        {
            if (espiritu.CompareTag("Spirit"))
            {
                RealizarBusquedaExitosa();
                return;  // Sal del bucle si encuentras al menos un espiritu
            }
        } */
        for (int i = 0; i < espiritus.Length; i++)
    {
        if (espiritus[i].CompareTag("Spirit"))
        {
            RealizarBusquedaExitosa();
            return;  // Sal del bucle si encuentras al menos un espiritu
        }
    }

        RealizarBusquedaFallida();
    }

    private void RealizarBusquedaExitosa()
    {
        zorrito.CambiarEstado(new EstadoLocalizacion());
    }

    private void RealizarBusquedaFallida()
    {
        zorrito.CambiarEstado(new EstadoSeguimiento());
        Debug.Log("Zorrito: No encontre nada");
    }
}