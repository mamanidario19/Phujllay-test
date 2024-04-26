using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PedidoAMesa : MonoBehaviour
{
    [SerializeField] private List<string> platillos = new List<string>();
    [SerializeField] private Transform jugador;

    void Update()
    {
        if (jugador != null)
        {
            transform.position = new Vector3(jugador.position.x, jugador.position.y + 1.7f, jugador.position.z);
        }
    }

    public void GuardarPlato(string nombrePlato)
    {
        platillos.Add(nombrePlato);
    }

    public void MostrarPlatos()
    {
        Debug.Log("Pedido: ");

        for (int i = 0; i < platillos.Count; i++)
        {
            Debug.Log("Platillo: " + platillos[i]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            jugador = other.transform;
        }

        if (other.gameObject.CompareTag("Comensal"))
        {
            other.gameObject.GetComponent<Orden>().VerificarOrden(platillos);

            Destroy(this.gameObject);
        }
    }
}
