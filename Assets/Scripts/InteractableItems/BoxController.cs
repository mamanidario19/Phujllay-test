/*Script que define la forma de interaccion de objeto*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour, IInteractable
{
    // Fuerza aplicada al empujar la caja
    public float pushForce = 10f;

    // Metodo de la interfaz IInteractable para la interaccion con la caja
    public void Interact()
    {
        // Aplica fuerza para empujar en la direccion frontal del objeto en cuestion
        GetComponent<Rigidbody>().AddForce(transform.forward * pushForce, ForceMode.Impulse);
    }
}