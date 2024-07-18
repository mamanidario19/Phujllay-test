using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjetToSite : MonoBehaviour
{
    public Transform objetTop; // Primer objeto a mover
    public Transform objectMid; // Segundo objeto a mover
    public Transform objetBot; // Tercer objeto a mover

    public Transform topSite; // Destino del primer objeto
    public Transform midSite; // Destino del segundo objeto
    public Transform botSite; // Destino del tercer objeto

    public void MoveObjectTop()
    {
       MoveObject(objetTop, topSite);
    }

    public void MoveObjectMid()
    {
        MoveObject(objectMid, midSite);
    }

    public void MoveObjectBot()
    {
        MoveObject(objetBot, botSite);
    }

    private void MoveObject(Transform objetToMove, Transform destinyPosition)
    {
        if (objetToMove != null && destinyPosition != null)
        {
            objetToMove.position = destinyPosition.position;
        }
    }
}