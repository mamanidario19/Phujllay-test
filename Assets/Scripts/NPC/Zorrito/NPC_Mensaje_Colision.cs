using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC_Mensaje_Colision : MonoBehaviour
{
    [SerializeField] private GameObject contenedor;
    [SerializeField] private string nombre;
    [SerializeField] private string descripcion;
    [SerializeField] private TextMeshProUGUI nombreTMP;
    [SerializeField] private TextMeshProUGUI descripcionTMP;
    [SerializeField] private float retraso = 0.1f;

    private void Start()
    {
        nombreTMP.text = nombre;
    }

    public void ActivarMensaje()
    {
        contenedor.SetActive(true);

        Debug.Log("ENTRO");

        StartCoroutine(MostrarMensaje());
    }

    public void ReiniciarMensaje()
    {
        StopAllCoroutines();

        descripcionTMP.text = "";

        contenedor.SetActive(false);
    }

    private IEnumerator MostrarMensaje()
    {
        descripcionTMP.text = "";

        foreach (char letra in descripcion.ToCharArray())
        {
            descripcionTMP.text += letra;

            yield return new WaitForSeconds(retraso);
        }
    }
}
