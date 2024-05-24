using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionAleatoria : MonoBehaviour
{
    private int[] transforms = { 0, 90, 180, 270 };

    private void Start()
    {
        transform.Rotate(0, transforms[ObtenerPosicionAleatoria()], 0);
    }

    private int ObtenerPosicionAleatoria()
    {
        return Random.Range(0, transforms.Length);
    }
}
