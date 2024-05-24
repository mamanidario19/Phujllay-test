using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Image[] spotsImagenes;
    [SerializeField] private Button botonPedido;
    [SerializeField] private GameObject prefabPedido;
    [SerializeField] private Transform posicionInstancia;

    [SerializeField] private bool accion;
    private int contador;

    private void Start()
    {
        accion = true;

        contador = 0;

        botonPedido.interactable = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && accion)
        {
            ActivarMenu();
        }
    }

    public void ActivarMenu()
    {
        LimpiarArreglo();

        menuPanel.SetActive(!menuPanel.activeSelf);
    }

    public void DesactivarMenu()
    {
        LimpiarArreglo();

        menuPanel.SetActive(false);
    }

    public void AgregarItem(Sprite item)
    {
        if (spotsImagenes[spotsImagenes.Length - 1].sprite != null) return;

        for (int i = 0; i < spotsImagenes.Length; i++)
        {
            if (spotsImagenes[i].sprite == null)
            {
                spotsImagenes[i].sprite = item;

                contador++;

                break;
            }
        }

        ControlarBoton();
    }

    public void LimpiarArreglo()
    {
        if (spotsImagenes[0].sprite == null) return;

        for (int i = 0;i < contador;i++)
        {
            if (spotsImagenes[i].sprite != null)
            {
                spotsImagenes[i].sprite = null;
            }
        }

        contador = 0;

        ControlarBoton();
    }

    private void ControlarBoton()
    {
        if (contador == spotsImagenes.Length)
        {
            botonPedido.interactable = true;
        }
        else
        {
            botonPedido.interactable = false;
        }
    }

    public void GenerarPedido()
    {
        string[] nombres = new string[spotsImagenes.Length];

        for(int i = 0; i < spotsImagenes.Length; i++)
        {
            string nombre = spotsImagenes[i].sprite.name;

            nombres[i] = nombre;
        }

        InstanciarPedido(nombres);
    }

    public void InstanciarPedido(string[] nombres)
    {
        GameObject pedido = Instantiate(prefabPedido, posicionInstancia.position, posicionInstancia.rotation);

        pedido.GetComponent<Pedido>().Platillos = nombres;

        pedido.transform.SetParent(posicionInstancia);

        DesactivarMenu();
    }    

    public bool Accion
    {
        get { return this.accion; }

        set { this.accion = value; }
    }
}
