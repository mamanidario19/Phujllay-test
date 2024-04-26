using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrega : MonoBehaviour
{
    private PedidoAMesa pedido;

    private void Start()
    {
        pedido = this.gameObject.GetComponent<PedidoAMesa>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
