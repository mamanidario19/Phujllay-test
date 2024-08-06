using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC_Mensaje : MonoBehaviour
{
    [SerializeField] private GameObject contenedor;
    [SerializeField] private string nombre;
    [SerializeField] private string descripcion;
    [SerializeField] private TextMeshProUGUI nombreTMP;
    [SerializeField] private TextMeshProUGUI descripcionTMP;
    [SerializeField] private float retraso = 0.1f;

    private bool activo = true;

    public bool Activo
    {
        get { return activo; }
        set { activo = value; }
    }

    private void Start()
    {
        nombreTMP.text = nombre;
    }

    private void Update()
    {
        if (activo) {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ActivarMensaje();

                activo = false;
            }
        }
    }

    public void ActivarMensaje()
    {
        contenedor.SetActive(true);

        StartCoroutine(MostrarMensaje());
    }

    public void ReiniciarMensaje()
    {
        StopAllCoroutines();

        descripcionTMP.text = "";

        contenedor.SetActive (false);
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
