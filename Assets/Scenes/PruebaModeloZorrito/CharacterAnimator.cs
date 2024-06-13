/* En esta clase llamamos a todas las animaciones cuando se la requieran */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    //Estas variables har�n referencia al objeto que contiene el Script que necesitemos acceder//
    public CharacterInput characterInput;
    public Animator anim;

    //M�todo que ejecutar� la animaci�n de correr//
    //public void Run()
    //{
    //    anim.SetFloat("speedX", characterInput.x);
    //    anim.SetFloat("speedY", characterInput.y);
    //}

    private void Update()
    {
        if (characterInput.y > 0)
        {
            Walk();
        }
        else
        {
            Idle();
        }
    }

    //M�todo que ejecutar� la animaci�n de salto//
    public void Jump()
    {
        anim.SetBool("jump", true);
    }

    //M�todo que ejecutar� la animaci�n de agacharse//
    public void IsCrouch()
    {
        anim.SetBool("crouch", true);
    }

    //M�todo que ejecutar� la animaci�n de levantarse//
    public void IsNotCrouch()
    {
        anim.SetBool("crouch", false);
    }

    //M�todo que ejecutar� la animaci�n al tocar el suelo//
    public void TouchGround()
    {
        anim.SetBool("touchGround", true);
    }

    //M�todo que ejecutar� la animaci�n de que est� cayendo//
    public void FallingDown()
    {
        anim.SetBool("touchGround", false);
        anim.SetBool("jump", false);
    }

    public void Walk()
    {
        anim.SetBool("isWalking", true);
    }

    public void Idle()
    {
        anim.SetBool("isWalking", false);
    }
}
