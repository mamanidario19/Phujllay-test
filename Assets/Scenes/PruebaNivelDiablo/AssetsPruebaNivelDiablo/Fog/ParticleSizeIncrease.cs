using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSizeIncrease : MonoBehaviour
{
    public ParticleSystem particleSystemFog; // El sistema de partículas
    public float increaseAmount = 1f; // Cuánto aumentar el tamaño cada vez
    public float increaseInterval = 2f; // Cada cuántos segundos aumentar el tamaño
    public float maxSize = 30f; // Tamaño máximo de partícula

    private float timer; // Un temporizador para llevar la cuenta del tiempo

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f; // Inicializa el temporizador a 0
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // Incrementa el temporizador

        // Si han pasado más de 'increaseInterval' segundos
        if (timer >= increaseInterval)
        {
            // Obtiene la configuración principal del sistema de partículas
            var main = particleSystemFog.main;

            // Incrementa el tamaño inicial de las partículas
            main.startSizeMultiplier += increaseAmount;

            // Limita el tamaño máximo
            main.startSizeMultiplier = Mathf.Min(main.startSizeMultiplier, maxSize);

            // Reinicia el temporizador
            timer = 0f;
        }
    }
}
