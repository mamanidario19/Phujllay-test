using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDirection : MonoBehaviour
{
    public SB_Slidebar sB_Slidebar;
    public bool isMovingUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sB_Slidebar.vel >= 0)
        {
            isMovingUp = true;
        }
        if (sB_Slidebar.vel <= 0)
        {
            isMovingUp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Afinador_Puntero")
        {
            sB_Slidebar.vel *= -1;
            //Debug.Log("Colisioné con el objeto");
        }
    }
}
