/* En esta clase detectaremos si el Trigger del personaje est� tocando el suelo o no */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundCheck : MonoBehaviour
{
    //Estas variables har�n referencia al objeto que contiene el Script que necesitemos acceder//
    public CharacterJump characterJump;

    //M�todos evaluar�n si el personaje est� tocando el suelo o no, devolviendo as� una variable booleana//
    private void OnTriggerStay(Collider other)
    {
        characterJump.canJump = true;
    }
    private void OnTriggerExit(Collider other)
    {
        characterJump.canJump = false;
    }
}
