using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTapas : MonoBehaviour
{
    public GameObject centerObject; // EmptyObject ubicación central

    public ObjectPuzzleModel[] tapasDataArray; // Array de Scriptable Objects de Tapas

    private int currentIndex = 0; // Indice actual de tapa

    private void Start()
    {
        // Muestra tapa inicial
        ShowTapa(currentIndex);
    }

    public void ChangeToLeftTapa()
    {
        // Cambia a la tapa de la izquierda
        currentIndex--;
        if (currentIndex < 0) currentIndex = tapasDataArray.Length - 1;
        ShowTapa(currentIndex);
    }

    public void ChangeToRightTapa()
    {
        // Cambia a la tapa de la derecha
        currentIndex++;
        if (currentIndex >= tapasDataArray.Length) currentIndex = 0;
        ShowTapa(currentIndex);
    }

    public void ShowTapa(int index)
    {
        // Muesta la tapa en el centro de la pantalla usando los datos del Scriptable Object
        GameObject newTapa = Instantiate(tapasDataArray[index].objectPrefab, centerObject.transform.position, centerObject.transform.rotation);
        Destroy(centerObject); // Eliminar la tapa anterior
        centerObject = newTapa; // Asignar la nueva tapa al centro
    }
}