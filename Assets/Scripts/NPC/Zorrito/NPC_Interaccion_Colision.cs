using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interaccion_Colision : MonoBehaviour
{
    [SerializeField] private GameObject mensaje;

    private NPC_Mensaje_Colision npcMensaje;

    private void Start()
    {
        npcMensaje = mensaje.GetComponent<NPC_Mensaje_Colision>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensaje.SetActive(true);

            npcMensaje.ActivarMensaje();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensaje.SetActive(false);

            npcMensaje.ReiniciarMensaje();
        }
    }
}
