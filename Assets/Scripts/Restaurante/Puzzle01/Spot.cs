using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Spot : MonoBehaviour
{
    [SerializeField] private bool activo = false;

    public bool Activo
    {
        get { return activo; }

        set { this.activo = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && transform.childCount == 0)
        {
            activo = false;
        }
    }
}
