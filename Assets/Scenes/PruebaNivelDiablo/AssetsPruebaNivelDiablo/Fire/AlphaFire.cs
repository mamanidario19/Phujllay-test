using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaFire : MonoBehaviour
{
    public ParticleSystem particleSystemFire; // Referencia al sistema de partículas
    public DarkenScreen darkenScreen;

    private void Start()
    {
        // Obtén la referencia al componente ParticleSystem
        particleSystemFire = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        // Cambia el canal alfa (transparencia) de las partículas
        var mainModule = particleSystemFire.main;
        Color startColor = mainModule.startColor.color;

        //// Si se presiona la tecla "Q", establece el valor alfa en 0.5
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    startColor.a = 0.5f;
        //}
        //else
        //{
        //    // De lo contrario, establece un valor aleatorio
        //    //startColor.a = Random.Range(0.2f, 1f); // Rango de valores alfa (0.2 a 1)
        //}

        // Calcula el valor objetivo del alpha
        float alphaObjetivo = darkenScreen.estaColisionando ? 0 : 1;

        // Cambia el alpha gradualmente hacia el valor objetivo
        startColor.a = Mathf.Lerp(startColor.a, alphaObjetivo, darkenScreen.velocidad * Time.deltaTime);

        mainModule.startColor = startColor;
    }
}