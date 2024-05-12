using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedido : MonoBehaviour
{
    [SerializeField] private string[] platillos;

    public string[] Platillos
    {
        get { return platillos; }

        set { platillos = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Transform hijoTransform = other.transform.Find("Posicion_Transporte");

            EliminarTodosLosHijos(hijoTransform);

            this.transform.SetParent(hijoTransform);

            this.transform.localPosition = Vector3.zero;

            this.transform.localRotation = Quaternion.Euler(-90f, 0f, 90f);
        }   
    }

    private void EliminarTodosLosHijos(Transform padre)
    {
        foreach (Transform hijo in padre)
        {
            Destroy(hijo.gameObject);
        }

        padre.DetachChildren();
    }
}
