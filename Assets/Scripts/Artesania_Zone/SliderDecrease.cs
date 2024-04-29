using UnityEngine;
using UnityEngine.UI;

public class SliderDecrease : MonoBehaviour
{
    public Slider slider;
    public float minValue = 0f;
    public float minDecreaseSpeed = 0.05f;
    public float maxDecreaseSpeed = 0.2f;
    public float minDirectionChangeInterval = 1f; // Tiempo minimo para cambiar direccion
    public float maxDirectionChangeInterval = 3f; // Tiempo maximo para cambiar direccion

    private float currentDecreaseSpeed;
    private float directionMultiplier = 1f; // Multiplicador de direccion
    private float nextDirectionChangeTime; // Tiempo para el proximo cambio de direccion

    void Start()
    {
        // Inicializar la velocidad de disminución y el tiempo para el proximo cambio de direccion
        currentDecreaseSpeed = Random.Range(minDecreaseSpeed, maxDecreaseSpeed);
        nextDirectionChangeTime = Time.time + Random.Range(minDirectionChangeInterval, maxDirectionChangeInterval);
    }

    void Update()
    {
        // Disminuir o aumentar el valor del Slider segun la direccion
        slider.value += currentDecreaseSpeed * Time.deltaTime * directionMultiplier;

        // Verificar límites y cambiar la direccion si es necesario
        if (slider.value <= minValue || slider.value >= slider.maxValue)
        {
            Debug.Log("Perdiste");
        }

        // Verificar si es momento de cambiar la direccion
        if (Time.time >= nextDirectionChangeTime)
        {
            ChangeSpeedAndDirection(); // Cambiar la velocidad y la direccion
            // Actualizar el tiempo para el proximo cambio
            nextDirectionChangeTime = Time.time + Random.Range(minDirectionChangeInterval, maxDirectionChangeInterval); // Actualizar el tiempo para el proximo cambio
        }
    }

    void ChangeSpeedAndDirection()
    {
        // Cambiar la velocidad de disminución de forma aleatoria
        currentDecreaseSpeed = Random.Range(minDecreaseSpeed, maxDecreaseSpeed);
        // Cambiar la dirección multiplicando por -1 de forma aleatoria
        directionMultiplier = Random.value < 0.5f ? 1f : -1f;
    }
}