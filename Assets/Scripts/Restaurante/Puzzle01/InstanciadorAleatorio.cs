using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class InstanciadorAleatorio : MonoBehaviour
{
    [SerializeField] private int tiempoInicial = 5;
    [SerializeField] private int tiempoRetraso = 5;
    [SerializeField] private int tiempoFinalizacion = 40;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Spot[] posiciones;

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

        Spot spot = GetSpotLibre();

        if (spot != null)
        {
            spot.Activo = true;

            GameObject instanciaPrefab = Instantiate(prefab, spot.transform.position, prefab.transform.rotation);

            instanciaPrefab.transform.SetParent(spot.transform);            
        }
    }

    private Spot GetSpotLibre()
    {
        List<Spot> spotsLibres = new List<Spot>();

        foreach (Spot spot in posiciones)
        {
            if (!spot.Activo) spotsLibres.Add(spot);
        }

        if (spotsLibres.Count > 0)
        {
            return spotsLibres[Random.Range(0, spotsLibres.Count)];
        }

        return null;
    }
}
