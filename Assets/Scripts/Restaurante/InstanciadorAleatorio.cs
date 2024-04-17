using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorAleatorio : MonoBehaviour
{
    [SerializeField] private int tiempoInicial = 5;
    [SerializeField] private int tiempoRetraso = 5;
    [SerializeField] private int tiempoFinalizacion = 40;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform[] posiciones;

    private void Start()
    {
        InvokeRepeating("Instanciar", tiempoInicial, tiempoRetraso);
    }

    private void Instanciar()
    {
        if (tiempoFinalizacion == 30)
        {
            CancelInvoke("Instanciar");

            return;
        }

        tiempoFinalizacion++;

        Transform spot = posiciones[Random.Range(0, posiciones.Length)];

        Instantiate(prefab, spot.position, prefab.transform.rotation);
    }
}
