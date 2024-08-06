using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interaccion : MonoBehaviour
{
    [SerializeField] private GameObject mensaje;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensaje.SetActive(true);

            mensaje.GetComponent<NPC_Mensaje>().Activo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mensaje.SetActive(false);

            NPC_Mensaje npcMensaje = mensaje.GetComponent<NPC_Mensaje>();

            if (npcMensaje != null)
            {
                npcMensaje.ReiniciarMensaje();
            }
        }
    }
}
