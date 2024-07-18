using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCompleteSlider : MonoBehaviour
{
    public Slider mainSlider; // El slider principal que controlamos
    public Slider secondarySlider; // El slider que aumentara su valor

    public float minValue = 0.40f; // Valor minimo para aumentar el slider secundario
    public float maxValue = 0.60f; // Valor maximo para aumentar el slider secundario
    public float increaseAmount = 0.05f; // Cantidad a aumentar en el slider secundario

    [SerializeField] GameObject _Character;
    [SerializeField] GameObject _CharacterAnimation;
    [SerializeField] GameObject _HUDmoldPuzzle;
    [SerializeField] GameObject _CameraPuzzle;

    void Update()
    {
        // Verificar si el valor del slider principal esta entre los limites
        if (mainSlider.value >= minValue && mainSlider.value <= maxValue)
        {
            // Aumentar el valor del slider secundario
            secondarySlider.value += increaseAmount * Time.deltaTime;
        }
         // Al llenar la barra 
         if (secondarySlider.value >= secondarySlider.maxValue)
            {
                Debug.Log("Ganaste!");  
                _Character.SetActive(true);
                _CharacterAnimation.SetActive(false);
                _HUDmoldPuzzle.SetActive(false);
                _CameraPuzzle.SetActive(false);

            }

         if (mainSlider.value <= 0 || mainSlider.value >= 1f )
        {
            Debug.Log("PERDISTE");
            _Character.SetActive(true);
            _CharacterAnimation.SetActive(false);
            _HUDmoldPuzzle.SetActive(false);
            _CameraPuzzle.SetActive(false);

        }
    }
}