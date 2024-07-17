using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorritoVision : MonoBehaviour
{
    public bool isWatching;
    public ZorritoNavMeshController zorritoNavMeshController;
    public GameObject MyCharacter;
    private float distanceMaxRayCast = 15.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPoint = transform.position;
        Vector3 directionRay = MyCharacter.transform.position - startPoint;
        if (zorritoNavMeshController.GuideStatus)
        {

        }
        RaycastHit hit;
        if (Physics.Raycast(startPoint, directionRay, out hit, distanceMaxRayCast))
        {
            if (hit.transform == MyCharacter.transform)
            {
                isWatching = true;
                //Debug.Log("Me esta viendo");
            }
            else
            {
                isWatching = false;
                //Debug.Log("No me esta viendo");
            }
        }
    }
}
