using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mensaje : MonoBehaviour
{
    [SerializeField] private string mensaje;
    [SerializeField] private GameObject panel;

    private void Start()
    {
        panel.GetComponentInChildren<TextMeshProUGUI>().text = mensaje;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
        }
    }
}
