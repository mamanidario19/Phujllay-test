using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CentralButton : MonoBehaviour
{
    public GameObject centerObject; // Objeto en el centro de la pantalla
    public Image centerButtonImage; // Referencia al componente Image del botón central
    public ObjectPuzzleModel[] tapaDataArray; // Array de Scriptable Objects que representan las tapas

    public PredefinedObjectSO predefinedObjectToCompare; // Referencia al PredefinedObjectSO que quieres comparar


    private int currentIndex = 0; // Indice actual del icono seleccionado

    private void Start()
    {
        // Muestra el primer icono al iniciar
        ChangeIcon(0);
    }

     public void ChangeIcon(int direction)
    {
        currentIndex += direction;
        if (currentIndex < 0) currentIndex = tapaDataArray.Length - 1;
        else if (currentIndex >= tapaDataArray.Length) currentIndex = 0;

        // Cambiar solo la imagen del botón central al icono correspondiente
        centerButtonImage.sprite = tapaDataArray[currentIndex].icon;
    }

     public void OnClick()
{
    if (centerObject.transform.childCount > 0)
    {
        Destroy(centerObject.transform.GetChild(0).gameObject); // Eliminar el objeto anterior
    }

    // Instanciar el nuevo objeto en el centro
    Instantiate(tapaDataArray[currentIndex].objectPrefab, centerObject.transform.position, centerObject.transform.rotation, centerObject.transform);

    CompareObjects();

}

    private void CompareObjects()
    {
        // Obtener el nombre del objeto instanciado
        string objectName = tapaDataArray[currentIndex].objectName;

        Debug.Log(objectName);

        
        // Comparar el nombre del objeto instanciado con el nombre del PredefinedObjectSO
        if (objectName == predefinedObjectToCompare.tapaType)
        {
            Debug.Log("El objeto instanciado coincide con el PredefinedObjectSO");
        }
        else
        {
            Debug.Log("El objeto instanciado NO coincide con el PredefinedObjectSO");
        }
        
    }
}