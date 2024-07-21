using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransicionEscena : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        animator.SetTrigger("Iniciar");
    }
}
