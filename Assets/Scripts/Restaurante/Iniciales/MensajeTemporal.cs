using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajeTemporal : MonoBehaviour
{
    [SerializeField] private float tiempoDeVida = 3f;

    private void Start()
    {
        StartCoroutine(DestruirDespuesDeTiempo());
    }

    IEnumerator DestruirDespuesDeTiempo()
    {
        yield return new WaitForSeconds(tiempoDeVida);

        this.gameObject.SetActive(false);
    }
}
