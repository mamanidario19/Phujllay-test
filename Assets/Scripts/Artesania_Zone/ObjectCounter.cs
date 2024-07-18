using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCounter : MonoBehaviour
{
    public TMP_Text counterText;
    public int totalObjects = 3; // Cantidad total de objetos a armar
    private int objectsAssembled = 0; // Cantidad de objetos armados

    void Start()
    {
        UpdateCounterText();
    }

    // Llamado cuando armas un objeto
    public void ObjectAssembled()
    {
        objectsAssembled++;
        UpdateCounterText();
    }

    // Actualiza el texto del contador
    void UpdateCounterText()
    {
        counterText.text = objectsAssembled + "/" + totalObjects;
    }
}