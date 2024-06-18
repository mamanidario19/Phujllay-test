using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayColliderDetected : MonoBehaviour
{
    public FlashEffect flashEffect; // Referencia al Script FlashEffect
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Este método se llama cuando el cilindro colisiona con otro objeto
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto con el que el cilindro ha colisionado tiene la etiqueta "Player"
        if (other.gameObject.tag == "Player")
        {
            // Aquí puedes definir lo que sucede cuando el cilindro colisiona con el jugador
            Debug.Log("Esta colisionando con " + other.name);
            flashEffect.isFlashActive = true;
        }
        //else
        //{
        //    flashEffect.isFlashActive = false;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        // Comprueba si el objeto con el que el cilindro ha dejado de colisionar tiene la etiqueta "Player"
        if (other.gameObject.tag == "Player")
        {
            flashEffect.isFlashActive = false;
        }
    }
}
