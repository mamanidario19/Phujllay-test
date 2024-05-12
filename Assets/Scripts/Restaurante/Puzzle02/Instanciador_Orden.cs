using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador_Orden : MonoBehaviour
{
    [SerializeField] GameObject pOrden;
    [SerializeField] Transform[] posiciones;

    private void Start()
    {
        for (int i = 0; i < posiciones.Length; i++)
        {
            Instanciar(posiciones[i]);
        }
    }

    private void Instanciar(Transform posicion)
    {
        GameObject instancia = Instantiate(pOrden, posicion.position, posicion.rotation);

        instancia.transform.SetParent(posicion);
    }
}
