using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFollowCharacter : MonoBehaviour
{
    public ChangeCloudDestination changeCloudDestination;
    public Transform destiny; // El destino al que la nube debe seguir
    public Transform father; // El objeto que será el padre
    public Transform son; // El objeto que será el hijo
    public float velocidad = 0.5f; // La velocidad de seguimiento, puedes ajustarla  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula la posición objetivo de la nube
        Vector3 posicionObjetivo = new Vector3(destiny.position.x, destiny.position.y, destiny.position.z);

        // Interpola entre la posición actual de la nube y la posición objetivo
        transform.position = Vector3.Lerp(transform.position, posicionObjetivo, velocidad * Time.deltaTime);
    }

    public void MakeSon()
    {
        // Hace que 'son' sea hijo de 'father'
        son.SetParent(father);
        changeCloudDestination.ChangeToCharacterLocation();
    }

    public void RemoveSon()
    {
        // Hace que 'son' deje de ser hijo de 'father'
        son.SetParent(null);
        changeCloudDestination.ChangeToHomeLocation();
    }
}
