using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCameraPuzzle : MonoBehaviour
{
    [SerializeField] GameObject _CameraPuzzleToActivate;
    //[SerializeField] GameObject _Player;
    //[SerializeField] GameObject _ObjectToRotate;
    //[SerializeField] float _RotationSpeed = 30f;
    [SerializeField] AudioClip puzzleSound; // Sonido de torno andando 
    [SerializeField] AudioClip vajillaSound; // Sonido de vajilla llenandose

    private AudioSource audioSource;
    private AudioSource vajillaAudioSource;
    //private AudioSource victoriaMoldSound;
    
    private bool _isInteracting = false;


    private void Start()
    {
        // Inicializar el componente AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = puzzleSound;
        audioSource.loop = true; 

        vajillaAudioSource = gameObject.AddComponent<AudioSource>();
        vajillaAudioSource.clip = vajillaSound;
        vajillaAudioSource.loop = true; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disparar evento
            InteractOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disparar evento
            InteractOff();
        }
    }

    private void InteractOn()
    {
        Debug.Log("Entrando al puzzle ");
        _CameraPuzzleToActivate.SetActive(true);
        _isInteracting = true;
       //_Player.SetActive(false);
       if (audioSource != null && !audioSource.isPlaying)
        {
            //audioSource.Play();
            //vajillaAudioSource.Play();
        }
    }

    private void InteractOff()
    {
        Debug.Log("Saliendo del puzzle");
        _CameraPuzzleToActivate.SetActive(false);
        _isInteracting = false;

        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
            vajillaAudioSource.Stop();
        }
        //_Player.SetActive(true);
    }

    private void Update()
    {
        if (_isInteracting)
        {
            RotateObject();
        }
    }
    
    private void RotateObject()
    {
        // Rotar objeto en eje Y
        //_ObjectToRotate.transform.Rotate(Vector3.up, _RotationSpeed * Time.deltaTime);
    }
}