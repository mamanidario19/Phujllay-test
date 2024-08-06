using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mensaje_Mision : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float desplazamientoEnX;
    //[SerializeField] private Vector2 targetMaxAnchor;
    [SerializeField] private float duracion = 1.0f;
    //[SerializeField] private float espera = 3.0f;
    //[SerializeField] private Mission padre;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        StartCoroutine(MoverAnchors());
    }

    IEnumerator MoverAnchors()
    {
        Vector2 inicialMinRT = rectTransform.offsetMin;

        Vector2 inicialMaxRT = -rectTransform.offsetMax;

        Vector2 left = rectTransform.offsetMin;

        Vector2 right = -rectTransform.offsetMax;

        left.x -= desplazamientoEnX;

        right.x -= desplazamientoEnX;

        float transcurrido = 0;

        while (transcurrido < duracion)
        {
            transcurrido += Time.deltaTime;

            float tiempo = Mathf.Clamp01(transcurrido / duracion);

            rectTransform.offsetMin = Vector2.Lerp(inicialMinRT, left, tiempo);

            rectTransform.offsetMax = Vector2.Lerp(inicialMaxRT, right, tiempo);

            yield return null;
        }

        //Vector2 inicialMinAnchor = rt.anchorMin;

        //Vector2 inicialMaxAnchor = rt.anchorMax;

        //float transcurrido = 0;

        //while (transcurrido < duracion)
        //{
        //    transcurrido += Time.deltaTime;

        //    float tiempo = Mathf.Clamp01(transcurrido / duracion);

        //    rt.anchorMin = Vector2.Lerp(inicialMinAnchor, minAnchor, tiempo);

        //    rt.anchorMax = Vector2.Lerp(inicialMaxAnchor, maxAnchor, tiempo);

        //    yield return null;
        //}

        //rt.anchorMin = minAnchor;

        //rt.anchorMax = maxAnchor;

        //yield return new WaitForSeconds(espera);

        //transcurrido = 0;

        //while (transcurrido < duracion)
        //{
        //    transcurrido += Time.deltaTime;

        //    float tiempo = Mathf.Clamp01(transcurrido / duracion);

        //    rt.anchorMin = Vector2.Lerp(minAnchor, inicialMinAnchor, tiempo);

        //    rt.anchorMax = Vector2.Lerp(maxAnchor, inicialMaxAnchor, tiempo);

        //    yield return null;
        //}

        //rt.anchorMin = inicialMinAnchor;

        //rt.anchorMax = inicialMaxAnchor;

        //padre.Destruir();
    }
}
