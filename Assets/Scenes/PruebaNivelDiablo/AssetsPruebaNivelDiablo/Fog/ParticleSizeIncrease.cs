using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSizeIncrease : MonoBehaviour
{
    public ParticleSystem particleSystemFog; // El sistema de part�culas
    public float increaseAmount = 1f; // Cu�nto aumentar el tama�o cada vez
    public float increaseInterval = 2f; // Cada cu�ntos segundos aumentar el tama�o
    public float maxSize = 30f; // Tama�o m�ximo de part�cula

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

        // Si han pasado m�s de 'increaseInterval' segundos
        if (timer >= increaseInterval)
        {
            // Obtiene la configuraci�n principal del sistema de part�culas
            var main = particleSystemFog.main;

            // Incrementa el tama�o inicial de las part�culas
            main.startSizeMultiplier += increaseAmount;

            // Limita el tama�o m�ximo
            main.startSizeMultiplier = Mathf.Min(main.startSizeMultiplier, maxSize);

            // Reinicia el temporizador
            timer = 0f;
        }
    }
}
