using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftButton : MonoBehaviour
{
    public CentralButton centralButton;

    public void OnClick()
    {
        centralButton.ChangeIcon(-1); // Cambiar al icono de la izquierda
    }
}