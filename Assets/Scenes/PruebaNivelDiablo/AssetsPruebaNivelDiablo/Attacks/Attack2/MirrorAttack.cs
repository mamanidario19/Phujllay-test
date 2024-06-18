using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorAttack : MonoBehaviour
{
    public float rayDistance = 25f; // La distancia que el rayo de luz puede viajar
    public Transform mirrorTransform; // El Transform del espejo desde donde se dispara el rayo
    public GameObject cylinder; // El objeto del cilindro que representa el rayo
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 endPoint;

        // Dispara un rayo de luz desde el espejo en la dirección en la que está mirando
        Ray ray = new Ray(mirrorTransform.position, mirrorTransform.forward);
        RaycastHit hit;

        // Dibuja el rayo en la escena
        Debug.DrawRay(mirrorTransform.position, mirrorTransform.forward * rayDistance, Color.red);

        // Si el rayo golpea algo
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Aquí puedes definir lo que sucede cuando el rayo golpea un objeto
            //Debug.Log("El rayo de luz ha golpeado a " + hit.transform.name);

            if (hit.transform.name == "Jugador")
            {
                //flashEffect.isFlashActive = true;
            }
            endPoint = mirrorTransform.position + mirrorTransform.forward * rayDistance;
        }
        else
        {
            // Si el rayo no golpea nada, el punto final será la distancia máxima del rayo
            endPoint = mirrorTransform.position + mirrorTransform.forward * rayDistance;
        }

        // Posiciona el cilindro en el punto de inicio del rayo
        cylinder.transform.position = mirrorTransform.position;

        // Rota el cilindro para que apunte en la misma dirección que el rayo
        Vector3 direction = endPoint - mirrorTransform.position;
        cylinder.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
        
        // Mueve el cilindro para que su extremo esté en el punto de inicio del rayo
        cylinder.transform.position += direction / 2;

    }
}
