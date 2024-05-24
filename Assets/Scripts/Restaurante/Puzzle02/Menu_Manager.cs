using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Manager : MonoBehaviour
{
    [SerializeField] private Menu menu;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            menu.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            menu.gameObject.SetActive(false);

            menu.DesactivarMenu();
        }
    }
}
