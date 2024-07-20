using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockAttack : MonoBehaviour
{
    public List<GameObject> rockPrefabs; // Lista de rocas
    public CameraShake cameraShake;
    public float dropHeight = 20f;
    public float rockSpacing = 2f;
    public float attackRadius = 5f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SomeOtherFunction();
            cameraShake.ShakeCamera();
        }
    }


    public void SomeOtherFunction()
    {
        // Obtén una referencia al objeto del juego
        GameObject myGameObject = GameObject.Find("Player"); // Referencia del player

        // Usa la posición del objeto como el centro del ataque
        Vector3 attackCenter = myGameObject.transform.position;

        // Llama a la función ExecuteAttack
        Attack1(attackCenter);
    }

    public void Attack1(Vector3 center)
    {
        StartCoroutine(DropRocks(center));
    }

    private IEnumerator DropRocks(Vector3 center)
    {
        for (int i = 0; i < 5; i++)
        {
            // Calcula una posición aleatoria dentro del área de ataque
            float randomX = Random.Range(-attackRadius, attackRadius);
            float randomZ = Random.Range(-attackRadius, attackRadius);
            Vector3 rockPosition = center + new Vector3(randomX, dropHeight, randomZ);
            
            // Selecciona un prefab aleatorio de la lista
            int randomPrefabIndex = Random.Range(0, rockPrefabs.Count);
            GameObject selectedRockPrefab = rockPrefabs[randomPrefabIndex];

            // Crea la roca
            Instantiate(selectedRockPrefab, rockPosition, Quaternion.identity);
            // Espera un poco antes de la próxima roca
            yield return new WaitForSeconds(0.5f);
        }
    }
}