using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionEscena : MonoBehaviour
{
    [SerializeField] private AnimationClip animacion;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(CambiarEscena());
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");

        yield return new WaitForSeconds(animacion.length);
    }
}
