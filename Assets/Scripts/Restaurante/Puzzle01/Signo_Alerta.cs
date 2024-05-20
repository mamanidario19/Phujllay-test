using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signo_Alerta : MonoBehaviour
{
    [SerializeField] private float velocidadVertical = 1f;
    [SerializeField] private float distanciaVertical = 2f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    private void Update()
    {
        float desplazamiento = Mathf.Sin(Time.time * velocidadVertical) * distanciaVertical;

        transform.position = posicionInicial + new Vector3(0f, desplazamiento, 0f);
    }
}
