using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagenTransform : MonoBehaviour
{
    [SerializeField] private int velocidadRotacion = 5;

    private void Update()
    {
        transform.Rotate(new Vector3(0, velocidadRotacion * Time.deltaTime, 0));
    }
}
