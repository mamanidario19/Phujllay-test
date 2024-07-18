using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireControl : MonoBehaviour
{
    public Slider fireSlider;
    public float minPosition = 0f;
    public float maxPosition = 1f;
    public float baseMoveSpeed = 0.1f;
    public float acceleration = 0.01f;
    public float maxMoveSpeed = 0.3f;

    private float targetPosition;
    private float currentVelocity;
    private float moveSpeed;

    public AudioClip pulseSound; // Sonido al presionar tecla
    private AudioSource audioSource;

    void Start()
    {
        // Inicializar la posicion del objeto a controlar 
        targetPosition = Random.Range(minPosition, maxPosition);
        fireSlider.value = targetPosition;
        moveSpeed = baseMoveSpeed;

         audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
      
        // Detectar la entrada del jugador para moverse
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveFireLeft();
            PlayPulseSound();
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveFireRight();
            PlayPulseSound();
        }
    }

    public void MoveFireLeft()
    {
        // Mover obj hacia la izquierda al llamar a esta funcion
        targetPosition = Mathf.Max(fireSlider.value - 0.1f, minPosition);
     
    }

    public void MoveFireRight()
    {
        // Mover obj hacia la derecha al llamar a esta funcion
        targetPosition = Mathf.Min(fireSlider.value + 0.1f, maxPosition);
       
    }
    private void PlayPulseSound()
    {
        if (pulseSound != null && audioSource != null)
        {
           // audioSource.PlayOneShot(pulseSound);
        }
    }
}