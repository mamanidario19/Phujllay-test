using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mision : MonoBehaviour
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

    public void Destruir()
    {
        Destroy(this.gameObject);
    }
}
