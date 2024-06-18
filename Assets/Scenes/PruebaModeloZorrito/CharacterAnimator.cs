/* En esta clase llamamos a todas las animaciones cuando se la requieran */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    //Estas variables harán referencia al objeto que contiene el Script que necesitemos acceder//
    public CharacterInput characterInput;
    public Animator anim;

    //Método que ejecutará la animación de correr//
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

    //Método que ejecutará la animación de salto//
    public void Jump()
    {
        anim.SetBool("jump", true);
    }

    //Método que ejecutará la animación de agacharse//
    public void IsCrouch()
    {
        anim.SetBool("crouch", true);
    }

    //Método que ejecutará la animación de levantarse//
    public void IsNotCrouch()
    {
        anim.SetBool("crouch", false);
    }

    //Método que ejecutará la animación al tocar el suelo//
    public void TouchGround()
    {
        anim.SetBool("touchGround", true);
    }

    //Método que ejecutará la animación de que está cayendo//
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
