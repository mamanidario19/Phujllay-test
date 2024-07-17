using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorizePlayPuzzle : MonoBehaviour
{
    // Variable pública para almacenar el estado de activación
    public bool thisObjectActive;

    private void OnEnable()
    {
        // Se llama cuando el objeto se activa
        thisObjectActive = true;
    }

    private void OnDisable()
    {
        // Se llama cuando el objeto se desactiva
        thisObjectActive = false;
    }
}