using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpeedIncrease : MonoBehaviour
{
    public ParticleSystem particleSystemFog; // El sistema de part�culas
    public float increaseAmountSpeed = 6.5f; // Cu�nto aumentar la velocidad inicial cada vez
    public float increaseAmountSimulation = 2.7f; // Cu�nto aumentar la velocidad de simulaci�n cada vez
    public float decreaseTime = 2f; // Cu�nto tiempo tardar en disminuir las velocidades
    public float maxStartSpeed = 7f; // Velocidad inicial m�xima
    public float maxSimulationSpeed = 3f; // Velocidad de simulaci�n m�xima

    private float baseStartSpeed; // Velocidad inicial base
    private float baseSimulationSpeed; // Velocidad de simulaci�n base

    // Start is called before the first frame update
    void Start()
    {
        var main = particleSystemFog.main;
        baseStartSpeed = main.startSpeedMultiplier;
        baseSimulationSpeed = main.simulationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Comprueba si la tecla V est� presionada
        if (Input.GetKeyDown(KeyCode.V))
        {
            IncreaseSpeeds();
            //// Obtiene la configuraci�n principal del sistema de part�culas
            //var main = particleSystemFog.main;

            //// Incrementa la velocidad inicial y la velocidad de simulaci�n
            //main.startSpeedMultiplier = maxStartSpeed;
            //main.simulationSpeed = maxSimulationSpeed;
        }

        // Comprueba si la tecla V se ha soltado
        if (Input.GetKeyUp(KeyCode.V))
        {
            DecreaseSpeeds();
        }
    }

    public void IncreaseSpeeds()
    {
        // Obtiene la configuraci�n principal del sistema de part�culas
        var main = particleSystemFog.main;

        // Incrementa la velocidad inicial y la velocidad de simulaci�n
        main.startSpeedMultiplier = maxStartSpeed;
        main.simulationSpeed = maxSimulationSpeed;
    }
    public void DecreaseSpeeds()
    {
        StartCoroutine(DecreaseSpeedFog());
    }

    private IEnumerator DecreaseSpeedFog()
    {
        var main = particleSystemFog.main;
        float t = 0;

        while (t < decreaseTime)
        {
            main.startSpeedMultiplier = Mathf.Lerp(maxStartSpeed, baseStartSpeed, t / decreaseTime);
            main.simulationSpeed = Mathf.Lerp(maxSimulationSpeed, baseSimulationSpeed, t / decreaseTime);
            t += Time.deltaTime;
            yield return null;
        }

        // Asegurarse de que las velocidades vuelvan a los valores base
        main.startSpeedMultiplier = baseStartSpeed;
        main.simulationSpeed = baseSimulationSpeed;
    }
}
