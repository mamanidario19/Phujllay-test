using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duendecillo : MonoBehaviour
{
    [SerializeField] private Transform[] puntos;
    [SerializeField] private float velocidad = 5.0f;
    [SerializeField] private float velocidadRotacion = 720.0f;
    [SerializeField] private Animator animator;

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

            Correr();
        }
    }

    private void Update()
    {
        if (moviendose)
        {
            Vector3 direccion = puntos[indice].position - transform.position;

            Vector3 nuevaPosicion = Vector3.MoveTowards(transform.position, puntos[indice].position, velocidad * Time.deltaTime);

            if (direccion != Vector3.zero)
            {
                Quaternion rotacionDestino = Quaternion.LookRotation(direccion);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionDestino, velocidadRotacion * Time.deltaTime);
            }

            transform.position = nuevaPosicion;

            if (transform.position == puntos[indice].position)
            {
                moviendose = false;

                Idle();
            }
        }
    }

    private void Correr()
    {
        animator.SetBool("corriendo?", true);
    }

    private void Idle()
    {
        animator.SetBool("corriendo?", false);
    }
}
