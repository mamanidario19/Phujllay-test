using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCameraPuzzle : MonoBehaviour
{
    [SerializeField] GameObject _CameraPuzzleToActivate;

    //[SerializeField] GameObject _Player;
    //[SerializeField] GameObject _ObjectToRotate;
    //[SerializeField] float _RotationSpeed = 30f;
    
    private bool _isInteracting = false;


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
    }

    private void InteractOff()
    {
        Debug.Log("Saliendo del puzzle");
        _CameraPuzzleToActivate.SetActive(false);
        _isInteracting = false;
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