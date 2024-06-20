using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNotes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Este m�todo se llama autom�ticamente cuando otro objeto entra en el trigger
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entr� al trigger es una nota musical
        if (other.gameObject.CompareTag("Note"))
        {
            // Si es una nota musical, destr�yela
            Destroy(other.gameObject);
        }
    }
}
