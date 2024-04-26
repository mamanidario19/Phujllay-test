using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedido : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            menu.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            menu.SetActive(false);
        }
    }
}
