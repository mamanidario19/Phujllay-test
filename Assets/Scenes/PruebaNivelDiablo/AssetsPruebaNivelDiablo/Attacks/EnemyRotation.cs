using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public Transform playerTransform; // Referencia al transform del jugador

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula la dirección desde el enemigo hacia el jugador
        Vector3 directionToPlayer = playerTransform.position - transform.position;

        // Ignora la altura (solo gira en el plano XZ)
        directionToPlayer.y = 0f;

        // Calcula la rotación deseada
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

        // Aplica la rotación gradualmente
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }
}
