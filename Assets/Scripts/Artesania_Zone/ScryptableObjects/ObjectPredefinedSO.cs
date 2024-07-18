using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PredefinedObject", menuName = "ScriptableObjects/PredefinedObject", order = 1)]
public class PredefinedObjectSO : ScriptableObject
{
    public string tapaType; // Tipo de tapa
    public string cuerpoType; // Tipo de cuerpo 
    public string baseType; // Tipo de base 
    public Sprite icon; // Icono de objeto completo
    public GameObject modelFinished; // Prefab del objeto 3D terminado
}