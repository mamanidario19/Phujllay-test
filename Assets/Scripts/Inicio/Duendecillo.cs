using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duendecillo : MonoBehaviour
{
    [SerializeField] private Transform[] puntos;
    [SerializeField] private float velocidad = 5.0f;

    private int indice = 0;
    private bool moviendose = false;

    private void Start()
    {
        if (puntos.Length > 0)
        {
            transform.position = puntos[indice].position;
        }
    }

    public void MoverAlSiguientePunto()
    {
        if (indice < puntos.Length - 1)
        {
            indice++;

            moviendose = true;
        }
    }

    private void Update()
    {
        if (moviendose)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntos[indice].position, velocidad * Time.deltaTime);

            if (transform.position == puntos[indice].position)
            {
                moviendose = false;
            }
        }
    }
}
