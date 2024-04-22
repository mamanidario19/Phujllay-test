using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{
    [SerializeField] private int velocidadRotacion = 5;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, velocidadRotacion * Time.deltaTime));
    }
}
