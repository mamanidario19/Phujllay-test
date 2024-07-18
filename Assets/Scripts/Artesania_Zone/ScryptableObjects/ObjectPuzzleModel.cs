using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObjectPuzzleModel", menuName = "PuzzleModelObject")]

public class ObjectPuzzleModel :  ScriptableObject
{
    public int objectID; // Identificador 
    public GameObject objectPrefab; // Prefab del objeto 3D
    public Sprite icon; // Icono del objeto
    public string objectName; 
}
