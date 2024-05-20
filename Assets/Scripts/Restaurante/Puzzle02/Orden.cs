using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Orden : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabPlatillos;
    [SerializeField] private GameObject[] prefabBebidas;
    [SerializeField] private Transform[] spotsPlatillos;
    [SerializeField] private Transform[] spotsBebidas;
    [SerializeField] private GameObject[] imagenesSpotPlatillos;
    [SerializeField] private GameObject[] imagenesSpotBebidas;
    [SerializeField] private GameObject panelOrden;    
    [SerializeField] private Sprite[] imagenesPlatillos;
    [SerializeField] private Sprite[] imagenesBebidas;
    [SerializeField] private GameObject imagenEntregado;
    [SerializeField] private GameObject imagenRechazado;
    [SerializeField] private GameObject platillos;
    [SerializeField] private GameObject bebidas;

    private List<string> nombresOrden = new List<string>();
    private string[] nombresPedido;
    private bool jugadorEnColision;
    private bool platilloEnColision;
    private Transform hijoTransform;

    private void Start()
    {
        nombresPedido = new string[imagenesSpotPlatillos.Length + imagenesSpotBebidas.Length];

        jugadorEnColision = false;

        platilloEnColision = false;

        GenerarOrden();

        AsignarImagenes();
    }

    private void Update()
    {
        if (jugadorEnColision && Input.GetKeyDown(KeyCode.E))
        {
            ActivarCanvas();
        }
        else if(platilloEnColision && Input.GetKeyDown(KeyCode.E))
        {
            EvaluarPlatillo();
        }
    }

    private void GenerarOrden()
    {
        CargarOrden(prefabPlatillos, spotsPlatillos.Length);

        CargarOrden(prefabBebidas, spotsBebidas.Length);
    }

    private void CargarOrden(GameObject[] objetos, int valorMaximo)
    {
        for (int i = 0; i < valorMaximo; i++)
        {
            nombresOrden.Add(objetos[ObtenerPosicionAleatoria(objetos.Length)].name);
        }
    }

    private void AsignarImagenes()
    {
        for (int i = 0; i < imagenesSpotPlatillos.Length; i++)
        {
            Image imagen = imagenesSpotPlatillos[i].GetComponent<Image>();

            imagen.sprite = imagenesPlatillos[ObtenerPosicion(imagenesPlatillos, nombresOrden[i])];
        }

        for (int i = 0; i < imagenesSpotBebidas.Length; i++)
        {
            Image imagen = imagenesSpotBebidas[i].GetComponent<Image>();

            imagen.sprite = imagenesBebidas[ObtenerPosicion(imagenesBebidas, nombresOrden[i + imagenesSpotPlatillos.Length])];
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

    // CANVAS
    public void ActivarCanvas()
    {
        panelOrden.SetActive(!panelOrden.activeSelf);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hijoTransform = other.transform.Find("Posicion_Transporte");

            if (!VerificarHijos(hijoTransform))
            {
                jugadorEnColision = true;
            }
            else
            {
                platilloEnColision = true;

                nombresPedido = hijoTransform.GetComponentInChildren<Pedido>().Platillos;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            jugadorEnColision = false;

            platilloEnColision = false;

            panelOrden.SetActive(false);

            Transform hijoTransform = other.transform.Find("Posicion_Transporte");

            EliminarTodosLosHijos(hijoTransform);
        }
    }

    private void ActivarMensaje(GameObject objeto)
    {
        objeto.SetActive(true);
    }

    // INSTANCIA DE PLATILLOS
    public bool VerificarHijos(Transform padre)
    {
        return padre.transform.childCount > 0;
    }

    public void EvaluarPlatillo()
    {
        if(CompararListados())
        {
            ColocarEnMEsa(ObtenerListaDeObjetos(prefabPlatillos), spotsPlatillos);

            ColocarEnMEsa(ObtenerListaDeObjetos(prefabBebidas), spotsBebidas);

            EliminarTodosLosHijos(hijoTransform);

            ActivarMensaje(imagenEntregado);

            DestruirOrden();
        }
        else
        {
            EliminarTodosLosHijos(hijoTransform);

            ActivarMensaje(imagenRechazado);

            jugadorEnColision = true;

            platilloEnColision = false;
        }
    }

    public bool CompararListados()
    {
        List<string> auxiliar = nombresOrden;

        for(int i = 0; i < nombresPedido.Length; i++)
        {
            for(int j = 0; j < auxiliar.Count; j++)
            {
                if (auxiliar[j] == nombresPedido[i])
                {
                    auxiliar.Remove(nombresPedido[i]);

                    break;
                }
            }
        }

        if(auxiliar.Count == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private List<GameObject> ObtenerListaDeObjetos(GameObject[] lista)
    {
        List<GameObject> auxiliar = new List<GameObject>();

        for(int i = 0; i < nombresPedido.Length; i++)
        {
            for(int j = 0; j < lista.Length; j++)
            {
                if (lista[j].name == nombresPedido[i])
                {
                    auxiliar.Add(lista[j]);

                    break;
                }
            }
        }

        return auxiliar;
    }

    public void ColocarEnMEsa(List<GameObject> lista, Transform[] spots)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            InstanciarPlatillo(lista[i], spots[i]);
        }
    }

    private void InstanciarPlatillo(GameObject objeto, Transform posicion)
    {
        GameObject instancia = Instantiate(objeto, posicion.position, posicion.rotation);

        instancia.transform.Rotate(-90f, 0f, 0f);

        instancia.transform.SetParent(posicion);
    }

    private void EliminarTodosLosHijos(Transform padre)
    {
        foreach (Transform hijo in padre)
        {
            Destroy(hijo.gameObject);
        }

        padre.DetachChildren();
    }

    private void DestruirOrden()
    {
        Transform nuevoPadre = this.gameObject.transform.parent;

        platillos.transform.SetParent(nuevoPadre);

        bebidas.transform.SetParent(nuevoPadre);

        Destroy(this.gameObject);
    }
}
