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

    public bool isActive = false; // Bandera para activar o desactivar el comportamiento

    public HUDPuzzleMoldInteraction hudPuzzleMoldInteraction; // Referencia a HUDPuzzleMoldInteraction


    void Start()
    {
        InitializeSlider();
    }

    void Update()
    {
        if (isActive) // Verificar si la bandera está activa
        {
            // Disminuir o aumentar el valor del Slider según la dirección
            slider.value += currentDecreaseSpeed * Time.deltaTime * directionMultiplier;

            // Verificar límites y cambiar la dirección si es necesario
            if (slider.value <= minValue || slider.value >= slider.maxValue)
            {
                Debug.Log("Perdiste");
                isActive = false;
                hudPuzzleMoldInteraction.InteractOff(); // Llamar a InteractOff

            }

            // Verificar si es momento de cambiar la dirección
            if (Time.time >= nextDirectionChangeTime)
            {
                ChangeSpeedAndDirection(); // Cambiar la velocidad y la dirección
                // Actualizar el tiempo para el próximo cambio
                nextDirectionChangeTime = Time.time + Random.Range(minDirectionChangeInterval, maxDirectionChangeInterval);
            }
        }
    }

    void ChangeSpeedAndDirection()
    {
        // Cambiar la velocidad de disminución de forma aleatoria
        currentDecreaseSpeed = Random.Range(minDecreaseSpeed, maxDecreaseSpeed);
        // Cambiar la dirección multiplicando por -1 de forma aleatoria
        directionMultiplier = Random.value < 0.5f ? 1f : -1f;
    }

    public void InitializeSlider()
    {
        // Inicializar la velocidad de disminución y el tiempo para el proximo cambio de direccion
        currentDecreaseSpeed = Random.Range(minDecreaseSpeed, maxDecreaseSpeed);
        nextDirectionChangeTime = Time.time + Random.Range(minDirectionChangeInterval, maxDirectionChangeInterval);
        // Poner el slider en el centro
        slider.value = (slider.maxValue + minValue) / 2f;
    }
}