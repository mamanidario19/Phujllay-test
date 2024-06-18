using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRock : MonoBehaviour
{
    public float autoDestroyTime = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, autoDestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto colisionado es del mismo tipo (prefab)
        if (collision.gameObject.CompareTag(gameObject.tag))
        {
            // No hace nada si colisiona con el mismo tipo de objeto
            return;
        }
        Destroy(gameObject);
    }
}
