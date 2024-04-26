using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orden : MonoBehaviour
{
    [SerializeField] private List<string> platillos = new List<string>();

    [SerializeField] private bool correcta = false;

    [SerializeField] private GameObject orden;

    public void VerificarOrden(List<string> platillosPedido)
    {
        correcta = CompararListas(platillos, platillosPedido);

        if (correcta)
        {
            Debug.Log("ORDEN CORRECTA, GRACIAS");

            Destroy(gameObject);
        }
        else
        {
            Debug.Log("ORDEN INCORRECTA, TRAEME LO QUE TE PEDI");
        }
    }

    private bool CompararListas(List<string> lista1, List<string> lista2)
    {
        if (lista1.Count != lista2.Count) return false;

        for (int i = 0; i < lista1.Count; i++)
        {
            if (lista1[i] != lista2[i]) return false;
        }

        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            orden.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            orden.SetActive(false);
        }        
    }
}
