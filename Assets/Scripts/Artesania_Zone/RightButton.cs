using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightButton : MonoBehaviour
{
    public CentralButton centralButton;

    public void OnClick()
    {
        centralButton.ChangeIcon(1); // Cambiar al icono de la derecha
    }
}