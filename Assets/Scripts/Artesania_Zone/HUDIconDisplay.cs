using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDIconDisplay : MonoBehaviour
{
    
    public PredefinedObjectSO iconSO1; // Scriptable Object con el icono 1
    public PredefinedObjectSO iconSO2; 
    public PredefinedObjectSO iconSO3; 

    public Image[] iconImages; // imagenes de los iconos en el HUD

    private void Start()
    {
        DisplayIcons();
    }

    private void DisplayIcons()
    {
        if (iconSO1 != null && iconSO2 != null && iconSO3 != null && iconImages.Length >= 3)
        {
            iconImages[0].sprite = iconSO1.icon; // icono 1 
            iconImages[1].sprite = iconSO2.icon; // icono 2 
            iconImages[2].sprite = iconSO3.icon; // icono 3 
        }
        else
        {
            Debug.LogWarning("Faltan imagenes");
        }
    }
    
}