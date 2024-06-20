using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressedNotes : MonoBehaviour
{
    public AuthorizePlayPuzzle authorizePlayPuzzle; // Referencia a la clase AuthorizePlayPuzzle
    public GuitarPuzzleManager guitarPuzzleManager;
    public GameObject notePrefab; // El objeto que puede pasar por este objeto
    public Material correctMaterial; // El material para cuando se presiona la tecla en el momento correcto
    public Material incorrectMaterial; // El material para cuando se presiona la tecla en el momento incorrecto
    public Material defaultMaterial; // El material por defecto del objeto
    public KeyCode keyToPress; // La tecla que se debe presionar

    public bool isColliding = false; // Si el objeto está actualmente en colisión
    private Renderer rend; // Renderer del objeto

    private GameObject collidingNote; // El objeto de la nota con el que se está colisionando

    void Start()
    {
        // Obtiene el Renderer del objeto
        rend = GetComponent<Renderer>();
        // Establece el material por defecto
        rend.material = defaultMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (authorizePlayPuzzle.thisObjectActive)
        {
            if (Input.GetKeyDown(keyToPress))
            {
                if (isColliding)
                {
                    StartCoroutine(ChangeMaterial(correctMaterial));
                    DestroyCorrectNote();
                    guitarPuzzleManager.incorrectPressCount = 0; // Reinicia el contador de presiones incorrectas
                }
                else
                {
                    StartCoroutine(ChangeMaterial(incorrectMaterial));
                    guitarPuzzleManager.incorrectPressCount++; // Aumenta el contador de presiones incorrectas
                }
            }
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {            
            isColliding = true;
            collidingNote = other.gameObject; // Guarda la referencia al objeto de la nota
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            isColliding = false;
            collidingNote = null; // Borra la referencia al objeto de la nota
        }
    }

    IEnumerator ChangeMaterial(Material newMaterial)
    {
        DestroyCorrectNote();
        rend.material = newMaterial;
        yield return new WaitForSeconds(0.1f);
        rend.material = defaultMaterial;
    }

    public void DestroyCorrectNote()
    {
        if (collidingNote != null)
        {
            Destroy(collidingNote); // Destruye el objeto de la nota
            isColliding = false;
        }        
    }
}