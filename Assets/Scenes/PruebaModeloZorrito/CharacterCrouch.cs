using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCrouch : MonoBehaviour
{
    //Estas variables har�n referencia al objeto que contiene el Script que necesitemos acceder//
    public CharacterMovement characterMovement;

    //M�todo que cambia la velocidad del movimiento si est� agachado//
    public void IsCrouch()
    {
        characterMovement.speedMov = characterMovement.speedCouch;
    }

    //M�todo que retoma la velocidad de mmovimiento cuando no est� agachado//
    public void IsNotCrouch()
    {
        characterMovement.speedMov = characterMovement.speed0;
    }
}