using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mensaje_Mision : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Vector2 targetMinAnchor;
    [SerializeField] private Vector2 targetMaxAnchor;
    [SerializeField] private float duracion = 1.0f;
    //[SerializeField] private float espera = 3.0f;
    [SerializeField] private Mission padre;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        StartCoroutine(MoverAnchors(rectTransform, targetMinAnchor, targetMaxAnchor, duracion));
    }

    IEnumerator MoverAnchors(RectTransform rt, Vector2 minAnchor, Vector2 maxAnchor, float duracion)
    {
        Vector2 inicialMinAnchor = rt.anchorMin;

        Vector2 inicialMaxAnchor = rt.anchorMax;

        float transcurrido = 0;

        while (transcurrido < duracion)
        {
            transcurrido += Time.deltaTime;

            float tiempo = Mathf.Clamp01(transcurrido / duracion);

            rt.anchorMin = Vector2.Lerp(inicialMinAnchor, minAnchor, tiempo);

            rt.anchorMax = Vector2.Lerp(inicialMaxAnchor, maxAnchor, tiempo);

            yield return null;
        }

        rt.anchorMin = minAnchor;

        rt.anchorMax = maxAnchor;

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
