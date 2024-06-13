using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador_Reposicion : MonoBehaviour
{
    [SerializeField] private Duendecillo duendecillo;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            duendecillo.MoverAlSiguientePunto();

            Destroy(this.gameObject);
        }
    }
}
