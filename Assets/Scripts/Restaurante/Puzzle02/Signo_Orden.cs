using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signo_Orden : MonoBehaviour
{
    [SerializeField] private float velocidadRotacion = 10f;
    [SerializeField] private float velocidadVertical = 1f;
    [SerializeField] private float distanciaVertical = 2f;

    private Vector3 posicionInicialLocal;

    void Start()
    {
        posicionInicialLocal = transform.localPosition;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, velocidadRotacion * Time.deltaTime));

        float desplazamiento = Mathf.Sin(Time.time * velocidadVertical) * distanciaVertical;

        transform.localPosition = new Vector3(posicionInicialLocal.x, posicionInicialLocal.y + desplazamiento, posicionInicialLocal.z);
    }
}
