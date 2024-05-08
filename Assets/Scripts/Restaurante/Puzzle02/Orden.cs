using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orden : MonoBehaviour
{
    [SerializeField] private GameObject[] pPlatillos;
    [SerializeField] private GameObject[] pBebidas;
    [SerializeField] private Transform[] spotsPlatillos;
    [SerializeField] private Transform[] spotsBebidas;
    [SerializeField] private GameObject[] imagenesSpotPlatillos;
    [SerializeField] private GameObject[] imagenesSpotBebidas;
    [SerializeField] private GameObject canvasOrden;
    [SerializeField] private Sprite[] imagenesPlatillos;
    [SerializeField] private Sprite[] imagenesBebidas;

    private List<string> nombresItems = new List<string>();

    private void Start()
    {
        GenerarOrden();

        AsignarImagenes();
    }

    private void GenerarOrden()
    {
        CargarOrden(pPlatillos, spotsPlatillos.Length);

        CargarOrden(pBebidas, spotsBebidas.Length);
    }

    private void CargarOrden(GameObject[] objetos, int valorMaximo)
    {
        for (int i = 0; i < valorMaximo; i++)
        {
            nombresItems.Add(objetos[ObtenerPosicionAleatoria(objetos.Length)].name);
        }
    }

    private void AsignarImagenes()
    {
        for (int i = 0; i < imagenesSpotPlatillos.Length; i++)
        {
            Image imagen = imagenesSpotPlatillos[i].GetComponent<Image>();

            imagen.sprite = imagenesPlatillos[ObtenerPosicion(imagenesPlatillos, nombresItems[i])];
        }

        for (int i = 0; i < imagenesSpotBebidas.Length; i++)
        {
            Image imagen = imagenesSpotBebidas[i].GetComponent<Image>();

            imagen.sprite = imagenesBebidas[ObtenerPosicion(imagenesBebidas, nombresItems[i + imagenesSpotPlatillos.Length])];
        }
    }

    private int ObtenerPosicion(Sprite[] imagenes, string nombre)
    {
        for(int i = 0;i < imagenes.Length;i++)
        {
            if (imagenes[i].name == nombre) return i;
        }

        return -1;
    }

    private int ObtenerPosicionAleatoria(int valorMaximo)
    {
        return UnityEngine.Random.Range(0, valorMaximo);
    } 
    
    // INSTANCIA DE PLATILLOS
    public void ColocarPlatillos(int[] indicePlatillos, int[] indiceBebidas)
    {
        for(int i = 0; i < spotsPlatillos.Length; i++)
        {
            InstanciarObjeto(pPlatillos[indicePlatillos[i]], spotsPlatillos[i]);
        }

        for (int i = 0; i < spotsBebidas.Length; i++)
        {
            InstanciarObjeto(pBebidas[indiceBebidas[i]], spotsBebidas[i]);
        }
    }

    private void InstanciarObjeto(GameObject objeto, Transform posicion)
    {
        GameObject instancia = Instantiate(objeto, posicion.position, posicion.rotation);

        instancia.transform.SetParent(posicion);
    }

    // CANVAS
    public void ActivarCanvas()
    {
        canvasOrden.SetActive(!canvasOrden.activeSelf);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ActivarCanvas();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            canvasOrden.SetActive(false);
        }
    }
}
