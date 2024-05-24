using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador_Comensal : MonoBehaviour
{
    [SerializeField] private GameObject comensal;
    [SerializeField] private Transform[] posiciones;

    private void Start()
    {
        for(int i = 0; i < posiciones.Length; i++)
        {
            GameObject instancia = Instantiate(comensal, posiciones[i].position, posiciones[i].rotation);

            instancia.transform.SetParent(posiciones[i]);
        }
    }
}
