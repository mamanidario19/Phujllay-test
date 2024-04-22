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
}
