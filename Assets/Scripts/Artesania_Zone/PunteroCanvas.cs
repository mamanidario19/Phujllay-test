using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunteroCanvas : MonoBehaviour
{
    public RectTransform puntero; 

    private void Update()
    {
        // Obtener la pos del mouse en pantalla
        Vector2 posicionMouse = Input.mousePosition;

        // Actualizar la pos del puntero en el canvas
        puntero.position = posicionMouse;
    }
}