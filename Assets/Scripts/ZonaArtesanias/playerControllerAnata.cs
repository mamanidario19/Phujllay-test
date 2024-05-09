using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class playerControllerAnata : MonoBehaviour
{
    private GameObject objetoSeleccionado;
    private anataPuzle anataPuzle;
    public float distanciaInteraccion = 6f; // Distancia mínima para interactuar con la mesa
    public CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        anataPuzle = FindObjectOfType<anataPuzle>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SeleccionarObjeto();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SoltarObjeto();
        }

        if (objetoSeleccionado != null)
        {
            MoverObjeto();
        }

        // Verificar la distancia a la mesa para interactuar
        if (Input.GetKeyDown(KeyCode.P))
        {
            VerificarDistanciaMesa();
        }
    }

    private void SeleccionarObjeto()
    {
        if (virtualCamera == null)
        {
            Debug.LogError("No se encontró una cámara virtual de Cinemachine.");
            return;
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10; // Ajustar la distancia al plano de la cámara

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 direction = worldPos - virtualCamera.transform.position;

        RaycastHit hit;
        if (Physics.Raycast(virtualCamera.transform.position, direction, out hit))
        {
            objetoSeleccionado = hit.collider.gameObject;
        }
    }

    private void SoltarObjeto()
    {
        objetoSeleccionado = null;
    }

    private void MoverObjeto()
    {
        if (objetoSeleccionado != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10; // Ajustar la distancia al plano de la cámara

            objetoSeleccionado.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }

    private void VerificarDistanciaMesa()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanciaInteraccion);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Mesa"))
            {
                anataPuzle.VerificarOrdenYRotacion();
                break;
            }
        }
    }
}