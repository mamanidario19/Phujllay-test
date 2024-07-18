using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsToGrab : MonoBehaviour
{
    public ZorritoAnimator zorritoAnimator;
    public ZorritoNavMeshController zorritoNavMeshController;
    public Animator anim;
    public List<GameObject> objectosAgarrables;
    public float radio = 3f;
    public Color colorRevelado = Color.green;
    public float duracionCambioColor = 2f;

    private float tiempoUltimaPresion = 0f;
    private float intervaloPresion = 6.1f;
    // Start is called before the first frame update
    void Start()
    {
        objectosAgarrables = new List<GameObject>(GameObject.FindGameObjectsWithTag("ObjetoRevelable"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && Time.time - tiempoUltimaPresion >= intervaloPresion)
        {
            anim.ResetTrigger("isIdle");
            anim.SetTrigger("isSniffing");
            Invoke("InvokeNotSniffing", 4.292f);
            RevelarObjetos();
            tiempoUltimaPresion = Time.time;
        }
    }

    void RevelarObjetos()
    {
        foreach (GameObject objeto in objectosAgarrables)
        {
            if (Vector3.Distance(transform.position, objeto.transform.position) <= radio)
            {
                StartCoroutine(CambiarColorGradualmente(objeto));
                //objeto.GetComponent<Renderer>().material.color = colorRevelado;
            }
        }
    }

    void InvokeNotSniffing()
    {
        //zorritoNavMeshController.speedY = 1.1f;
        zorritoAnimator.anim.SetTrigger("isIdle");
    }

    IEnumerator CambiarColorGradualmente(GameObject objeto)
    {
        Color colorOriginal = objeto.GetComponent<Renderer>().material.color;
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracionCambioColor)
        {
            tiempoTranscurrido += Time.deltaTime;
            float t = tiempoTranscurrido / duracionCambioColor;

            objeto.GetComponent<Renderer>().material.color = Color.Lerp(colorOriginal, colorRevelado, t);

            yield return null;
        }
        yield return new WaitForSeconds(2f);

        StartCoroutine(RevertirColorGradualmente(objeto, colorOriginal));
    }

    IEnumerator RevertirColorGradualmente(GameObject objeto, Color colorOriginal)
    {
        Color colorActual = objeto.GetComponent<Renderer>().material.color;
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracionCambioColor)
        {
            tiempoTranscurrido += Time.deltaTime;
            float t = tiempoTranscurrido / duracionCambioColor;

            objeto.GetComponent<Renderer>().material.color = Color.Lerp(colorActual, colorOriginal, t);

            yield return null;
        }

    }
}
