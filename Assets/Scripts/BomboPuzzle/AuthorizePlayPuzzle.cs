using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuthorizePlayPuzzle : MonoBehaviour
{
    public Festival_PuzzlesController festival_PuzzlesController;
    // Variable pública para almacenar el estado de activación
    public bool thisObjectActive;

    private void OnEnable()
    {
        // Se llama cuando el objeto se activa
        thisObjectActive = true;
        festival_PuzzlesController.numBack = 1;
    }

    private void OnDisable()
    {
        // Se llama cuando el objeto se desactiva
        thisObjectActive = false;
        festival_PuzzlesController.numBack = 0;
    }
}