using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkenScreen : MonoBehaviour
{
    public Transform personaje; // El personaje al que la nube debe seguir
    public CanvasGroup canvasGroup; // El CanvasGroup que controla el alpha
    public float velocidad = 0.1f; // La velocidad de cambio del alpha

    public bool estaColisionando = false; // Indica si la nube est� colisionando con el personaje

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula el valor objetivo del alpha
        float alphaObjetivo = estaColisionando ? 1 : 0;

        // Cambia el alpha del CanvasGroup gradualmente hacia el valor objetivo
        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, alphaObjetivo, velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si la nube ha comenzado a colisionar con el personaje
        if (other.gameObject.tag == "Player")
        {
            // Aqu� puedes definir lo que sucede cuando la nube colisiona con el jugador
            estaColisionando = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Comprueba si la nube ha dejado de colisionar con el personaje
        if (other.gameObject.tag == "Player")
        {
            estaColisionando = false;
        }
    }
}
