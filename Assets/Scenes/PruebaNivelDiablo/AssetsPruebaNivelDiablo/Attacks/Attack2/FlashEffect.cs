using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    public float flashDuration = 1f; // Duración del flash en segundos
    private CanvasGroup canvasGroup; // El Canvas Group que controla la opacidad del flash
    public bool isFlashActive = false;

    void Start()
    {
        // Obtiene el Canvas Group
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        // Si se presiona la tecla F, inicia el flash
        if (isFlashActive)
        {
            FlashActive();
            // Asegura de que el booleano solo se active en un solo frame.
            isFlashActive = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            FlashActive();
        }
    }

    private void FlashActive()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(1f);
        // Guarda el tiempo de inicio del flash
        float startTime = Time.time;

        // Mientras no haya pasado el tiempo de duración del flash
        while (Time.time < startTime + flashDuration)
        {
            // Calcula cuánto tiempo ha pasado desde el inicio del flash
            float elapsed = Time.time - startTime;

            // Calcula la opacidad del flash en función del tiempo transcurrido
            canvasGroup.alpha = 1f - (elapsed / flashDuration);

            // Espera hasta el próximo frame
            yield return null;
        }

        // Asegura que la opacidad del flash sea 0 al finalizar
        canvasGroup.alpha = 0f;
    }
}
