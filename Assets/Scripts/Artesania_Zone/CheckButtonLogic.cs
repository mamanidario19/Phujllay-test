using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButtonLogic : MonoBehaviour
{
    public GameObject topSection; // Referencia al objeto TopSection en la escena
    public GameObject bottomSection; // Referencia al objeto BottomSection en la escena
    public GameObject middleSection; // Referencia al objeto MiddleSection en la escena

    public PredefinedObjectSO[] predefinedObjects; // Array de Scriptable Objects que representan los objetos a armar
    private int currentPredefinedIndex = 0; // Índice actual del objeto predefinido

    public Image predefinedObjectImage; // Referencia al componente Image que mostrará la imagen del objeto predefinido
    public ObjectCounter objectCounter;

    public AudioClip successSound; // Sonido para el acierto
    public AudioClip failureSound; // Sonido para el fallo
    public AudioClip victorySound; // Sonido para victoria
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        UpdatePredefinedObjectImage(); // Actualizar la imagen al inicio
    }

    public void CompareObjects()
    {
        string nameTopChild = topSection.transform.childCount > 0 ? topSection.transform.GetChild(0).name : "";
        string nameMiddleChild = middleSection.transform.childCount > 0 ? middleSection.transform.GetChild(0).name : "";
        string nameBottomChild = bottomSection.transform.childCount > 0 ? bottomSection.transform.GetChild(0).name : "";

        // Comparar con el objeto predefinido actual
        if (nameTopChild == predefinedObjects[currentPredefinedIndex].tapaType + "(Clone)" &&
            nameMiddleChild == predefinedObjects[currentPredefinedIndex].cuerpoType + "(Clone)" &&
            nameBottomChild == predefinedObjects[currentPredefinedIndex].baseType + "(Clone)")
        {
            Debug.Log("Todos los objetos coinciden con el objeto predefinido actual.");
            objectCounter.ObjectAssembled();
            PlaySound(successSound);
            // Mover al siguiente objeto predefinido solo si todos coinciden
            MoveToNextPredefinedObject();
            UpdatePredefinedObjectImage();

            if (currentPredefinedIndex >= predefinedObjects.Length-1)
            {
                // Todos los objetos han sido completados
                PlaySound(victorySound);
                 Debug.Log("GANASTE.");
            }
        }
        else
        {
            Debug.Log("Algunos objetos no coinciden con el objeto predefinido actual.");
            PlaySound(failureSound);
        }
    }

    private void MoveToNextPredefinedObject()
    {
        // Incrementar el índice para mover al siguiente objeto predefinido
        currentPredefinedIndex++;

        // SEguro para no salirse del rango del array de objetos predefinidos
        currentPredefinedIndex = Mathf.Clamp(currentPredefinedIndex, 0, predefinedObjects.Length - 1);

        // Obtener el objeto predefinido actual
        PredefinedObjectSO currentPredefinedObject = predefinedObjects[currentPredefinedIndex];

        Debug.Log("Se ha movido al siguiente objeto predefinido: " + currentPredefinedObject.name);
    }

    // Actualizamos icono de objetos a completar
    private void UpdatePredefinedObjectImage()
    {
        predefinedObjectImage.sprite = predefinedObjects[currentPredefinedIndex].icon;
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

}