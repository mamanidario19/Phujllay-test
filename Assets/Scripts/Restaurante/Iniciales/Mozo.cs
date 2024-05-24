using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mozo : MonoBehaviour
{
    [SerializeField] private GameObject[] puzzles;

    private bool activo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && activo)
        {
            ActivarPuzzles();

            enabled = false;
        }
    }

    private void ActivarPuzzles()
    {
        for(int i = 0; i < puzzles.Length; i++)
        {
            puzzles[i].gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activo = false;
        }
    }
}
