/* En esta clase detectaremos si el Trigger del personaje está tocando el suelo o no */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGroundCheck : MonoBehaviour
{
    //Estas variables harán referencia al objeto que contiene el Script que necesitemos acceder//
    public CharacterJump characterJump;

    //Métodos evaluarán si el personaje está tocando el suelo o no, devolviendo así una variable booleana//
    private void OnTriggerStay(Collider other)
    {
        characterJump.canJump = true;
    }
    private void OnTriggerExit(Collider other)
    {
        characterJump.canJump = false;
    }
}
