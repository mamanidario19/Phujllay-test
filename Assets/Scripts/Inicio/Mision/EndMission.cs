using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMission : MonoBehaviour
{
    [SerializeField] private GameObject missionToEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            missionToEnd.GetComponent<Mission>().Destruir();

            Destroy(this.gameObject);
        }
    }
}
