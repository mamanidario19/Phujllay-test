/*Script que define la forma de interaccion de objeto*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopUpController : MonoBehaviour
{
    public Text messageCanvas; // componente Text del Canvas
    public float displayTime = 6f; //variable tiempo visible

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activa el Canvas y muestra el mensaje
            messageCanvas.gameObject.SetActive(true);

            // Despues de los segundos establecidos desactiva el texto
            Invoke("HideMessage", displayTime);
        }
    }

    private void HideMessage()
    {
        // Desactiva el Canvas despues del tiempo especificado
        messageCanvas.gameObject.SetActive(false);
    }
}